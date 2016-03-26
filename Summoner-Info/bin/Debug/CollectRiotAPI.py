from RiotAPI import RiotAPI
from collections import OrderedDict
import time
import json
import sys

user_api_key = 'bfbf03bb-ce02-434d-a86e-beed8a3602c6' # insert api key here
global_mid_list = []
global_sid_list = []
api = RiotAPI(user_api_key)
mid_index = 0

def getFirstId(ingamename):
    resp = api.get_summoner_by_name(ingamename)[0]
    return resp[ingamename]['id']


def getRecentGames(summid):
    resp = api.get_matchlist_by_summid(summid)[0]
    return resp


def addMatchIdToData(mid_set):
    global global_mid_list
    for match in mid_set:
        if match['queue'] == 'TEAM_BUILDER_DRAFT_RANKED_5x5':
            global_mid_list.append(match['matchId'])
    global_mid_list = list(OrderedDict.fromkeys(global_mid_list))

def getMatchData(mid_index):
    match = api.get_match(global_mid_list[mid_index])[0]
    getSummId(match)
    return match

def getSummId(match):
    global global_sid_list
    for i in range(10):
        global_sid_list.append(match['participantIdentities'][i]['player']['summonerId'])
    global_sid_list = list(OrderedDict.fromkeys(global_sid_list))

def nameToData(ingamename):
    sid = getFirstId(ingamename)
    mid_set = getRecentGames(sid)['matches']
    addMatchIdToData(mid_set)

def loop(write_file, ingamename):
    global mid_index
    try:
        while mid_index<len(global_mid_list):
            
            write_file.write(json.dumps(getMatchData(mid_index)))
            write_file.write('\n')
            mid_index += 1

    except KeyError:
        print("Key Error")
        time.sleep(15)
        mid_index +=1
        loop(write_file, ingamename)
        

def main(initial_mid_index=0):
    try:
        write_file = open('RiotTemp.txt', 'a') #output file
        ingamename = sys.argv[1].lower()
        nameToData(ingamename)
        loop(write_file, ingamename) #player
        
    
    except IndexError:
        print("Index Error; argument required")
    
    finally:
        write_file.close()
        print("done")

    
if __name__ == "__main__":
    main()
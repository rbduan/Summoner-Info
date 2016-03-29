﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summoner_Info
{

    public class rawMatchData
    {
        public string matchMode { get; set; }
        public string region { get; set; }
        public Participantidentity[] participantIdentities { get; set; }
        public int matchId { get; set; }
        public long matchCreation { get; set; }
        public string queueType { get; set; }
        public string matchType { get; set; }
        public string platformId { get; set; }
        public Team[] teams { get; set; }
        public int mapId { get; set; }
        public Participant[] participants { get; set; }
        public int matchDuration { get; set; }
        public string matchVersion { get; set; }
        public string season { get; set; }
    }

    public class Participantidentity
    {
        public int participantId { get; set; }
        public Player player { get; set; }
    }

    public class Player
    {
        public int summonerId { get; set; }
        public string summonerName { get; set; }
        public int profileIcon { get; set; }
        public string matchHistoryUri { get; set; }
    }

    public class Team
    {
        public int vilemawKills { get; set; }
        public Ban[] bans { get; set; }
        public bool firstDragon { get; set; }
        public int dominionVictoryScore { get; set; }
        public bool firstRiftHerald { get; set; }
        public bool winner { get; set; }
        public int towerKills { get; set; }
        public int inhibitorKills { get; set; }
        public int teamId { get; set; }
        public bool firstBlood { get; set; }
        public bool firstInhibitor { get; set; }
        public bool firstTower { get; set; }
        public int baronKills { get; set; }
        public int dragonKills { get; set; }
        public bool firstBaron { get; set; }
        public int riftHeraldKills { get; set; }
    }

    public class Ban
    {
        public int pickTurn { get; set; }
        public int championId { get; set; }
    }

    public class Participant
    {
        public int teamId { get; set; }
        public Timeline timeline { get; set; }
        public Rune[] runes { get; set; }
        public int participantId { get; set; }
        public string highestAchievedSeasonTier { get; set; }
        public int spell1Id { get; set; }
        public Mastery[] masteries { get; set; }
        public int championId { get; set; }
        public Stats stats { get; set; }
        public int spell2Id { get; set; }
    }

    public class Timeline
    {
        public Xpdiffpermindeltas xpDiffPerMinDeltas { get; set; }
        public Damagetakenpermindeltas damageTakenPerMinDeltas { get; set; }
        public Csdiffpermindeltas csDiffPerMinDeltas { get; set; }
        public Xppermindeltas xpPerMinDeltas { get; set; }
        public string lane { get; set; }
        public Damagetakendiffpermindeltas damageTakenDiffPerMinDeltas { get; set; }
        public string role { get; set; }
        public Goldpermindeltas goldPerMinDeltas { get; set; }
        public Creepspermindeltas creepsPerMinDeltas { get; set; }
    }

    public class Xpdiffpermindeltas
    {
        public float zeroToTen { get; set; }
        public float tenToTwenty { get; set; }
        public float twentyToThirty { get; set; }
    }

    public class Damagetakenpermindeltas
    {
        public float zeroToTen { get; set; }
        public float tenToTwenty { get; set; }
        public float twentyToThirty { get; set; }
    }

    public class Csdiffpermindeltas
    {
        public float zeroToTen { get; set; }
        public float tenToTwenty { get; set; }
        public float twentyToThirty { get; set; }
    }

    public class Xppermindeltas
    {
        public float zeroToTen { get; set; }
        public float tenToTwenty { get; set; }
        public float twentyToThirty { get; set; }
    }

    public class Damagetakendiffpermindeltas
    {
        public float zeroToTen { get; set; }
        public float tenToTwenty { get; set; }
        public float twentyToThirty { get; set; }
    }

    public class Goldpermindeltas
    {
        public float zeroToTen { get; set; }
        public float tenToTwenty { get; set; }
        public float twentyToThirty { get; set; }
    }

    public class Creepspermindeltas
    {
        public float zeroToTen { get; set; }
        public float tenToTwenty { get; set; }
        public float twentyToThirty { get; set; }
    }

    public class Stats
    {
        public int item4 { get; set; }
        public int neutralMinionsKilledTeamJungle { get; set; }
        public int item5 { get; set; }
        public int largestMultiKill { get; set; }
        public int quadraKills { get; set; }
        public int wardsKilled { get; set; }
        public int champLevel { get; set; }
        public int goldSpent { get; set; }
        public int tripleKills { get; set; }
        public int largestKillingSpree { get; set; }
        public int totalTimeCrowdControlDealt { get; set; }
        public int minionsKilled { get; set; }
        public int neutralMinionsKilledEnemyJungle { get; set; }
        public int objectivePlayerScore { get; set; }
        public bool firstBloodKill { get; set; }
        public int item0 { get; set; }
        public int deaths { get; set; }
        public int totalDamageDealtToChampions { get; set; }
        public int totalDamageDealt { get; set; }
        public int totalHeal { get; set; }
        public int killingSprees { get; set; }
        public int goldEarned { get; set; }
        public bool firstTowerAssist { get; set; }
        public int item1 { get; set; }
        public int sightWardsBoughtInGame { get; set; }
        public int trueDamageDealt { get; set; }
        public bool firstInhibitorKill { get; set; }
        public int totalScoreRank { get; set; }
        public int trueDamageTaken { get; set; }
        public bool firstBloodAssist { get; set; }
        public int neutralMinionsKilled { get; set; }
        public int inhibitorKills { get; set; }
        public int unrealKills { get; set; }
        public int trueDamageDealtToChampions { get; set; }
        public int physicalDamageDealtToChampions { get; set; }
        public bool winner { get; set; }
        public int magicDamageDealtToChampions { get; set; }
        public int totalDamageTaken { get; set; }
        public int largestCriticalStrike { get; set; }
        public int towerKills { get; set; }
        public int physicalDamageDealt { get; set; }
        public bool firstInhibitorAssist { get; set; }
        public int assists { get; set; }
        public bool firstTowerKill { get; set; }
        public int item3 { get; set; }
        public int pentaKills { get; set; }
        public int magicDamageDealt { get; set; }
        public int wardsPlaced { get; set; }
        public int item2 { get; set; }
        public int totalUnitsHealed { get; set; }
        public int visionWardsBoughtInGame { get; set; }
        public int kills { get; set; }
        public int totalPlayerScore { get; set; }
        public int item6 { get; set; }
        public int physicalDamageTaken { get; set; }
        public int doubleKills { get; set; }
        public int combatPlayerScore { get; set; }
        public int magicDamageTaken { get; set; }
    }

    public class Rune
    {
        public int runeId { get; set; }
        public int rank { get; set; }
    }

    public class Mastery
    {
        public int rank { get; set; }
        public int masteryId { get; set; }
    }

}

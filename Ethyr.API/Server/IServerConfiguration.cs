using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.API.Server
{
  public interface IServerConfiguration
  {
    string Name { get; }
    string Description { get; }
    string URL { get; }
    string Password { get; }
    string ConfirmationText { get; }

    int Port { get; }
    ServerVisibility Visibility { get; }
    string[] DisabledNetworkProtocols { get; }
    int MaxWorldTransferSpeed { get; }

    int MaxPlayerCount { get; }
    int ReservedSlots { get; }
    int AdminSlots { get; }

    bool IsTelnetEnabled { get; }
    int TelnetPort { get; }
    string TelnetPassword { get; }
    int TelnetFailedLoginAttempts { get; }

    bool IsEACEnabled { get; }
    bool HasPersistentProfiles { get; }

    GameMode DefaultGameMode { get; }
    int Difficulty { get; }
    string GameWorld { get; }
    string WorldSeed { get; }
    int WorldSize { get; }
    int BlockDamagePlayer { get; }
    int BlockDamageAI { get; }
    int BlockDamageAIBloodMoon { get; }
    int XPMultiplier { get; }
    int PlayerSafeZoneLevel { get; }
    int PlayerSafeZoneHours { get; }

    int DayLength { get; }
    int DaylightHours { get; }
    DropConfiguration DropOnDeath { get; }
    DropConfiguration DropOnQuit { get; }
    int BedrollDeadZoneSize { get; }
    int BedrollExpiryTime { get; }

    int MaxZombieCount { get; }
    int MaxAnimalCount { get; }
    int ViewDistance { get; }

    AISpeed ZombieSpeed { get; }
    AISpeed ZombieSpeedNight { get; }
    AISpeed ZombieFeralSpeed { get; }
    AISpeed ZombieBloodMoonSpeed { get; }

    bool IsBloodMoonStatic { get; }
    int BloodMoonChance { get; }
    int BloodMoonHourWarning { get; }
    int BloodMoonEnemyCount { get; }

    int LootAbundance { get; }
    int LootRespawnDays { get; }

    int AirDropFrequency { get; }
    bool HasAirDropMarker { get; }

    int PartySharedKillRange { get; }
    PVPMode PVPMode { get; }

    int LandClaimCount { get; }
    int LandClaimSize { get; }
    int LandClaimDeadZone { get; }
    int LandClaimExpiryTime { get; }
    DecayMode LandClaimDecayMode { get; }
    int LandClaimOnlineDurabilityModifier { get; }
    int LandClaimOfflineDurabilityModifier { get; }
  }
}

using Ethyr.API;
using Ethyr.API.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ethyr.Config
{
  [JsonObject(MemberSerialization.OptIn, ItemRequired = Required.AllowNull)]
  public class JsonConfiguration : IServerConfiguration
  {
    [JsonProperty("name")]
    public string Name { get; } = "An Ethyr Server";

    [JsonProperty("description")]
    public string Description { get; } = "This server is running on Ethyr";

    [JsonProperty("url")]
    public string URL { get; }

    [JsonProperty("password")]
    public string Password { get; }

    [JsonProperty("confirmationText")]
    public string ConfirmationText { get; }

    [JsonProperty("port")]
    public int Port { get; } = 26900;

    [JsonProperty("visibility")]
    public ServerVisibility Visibility { get; } = ServerVisibility.Public;

    [JsonProperty("disabledNetworkProtocols")]
    public string[] DisabledNetworkProtocols { get; } = new string[0];

    [JsonProperty("maxWorldTransferSpeed")]
    public int MaxWorldTransferSpeed { get; } = 1024;

    [JsonProperty("playerCount")]
    public int MaxPlayerCount { get; } = 8;

    [JsonProperty("reservedSlots")]
    public int ReservedSlots { get; }

    [JsonProperty("adminSlots")]
    public int AdminSlots { get; }

    [JsonProperty("isTelnetEnabled")]
    public bool IsTelnetEnabled { get; }

    [JsonProperty("telnetPort")]
    public int TelnetPort { get; } = 8081;

    [JsonProperty("telnetPassword")]
    public string TelnetPassword { get; } = "ChangeMe";

    [JsonProperty("telnetFailedLoginAttempts")]
    public int TelnetFailedLoginAttempts { get; } = 3;

    [JsonProperty("isEACEnabled")]
    public bool IsEACEnabled { get; } = true;

    [JsonProperty("hasPersistentProfiles")]
    public bool HasPersistentProfiles { get; } = true;

    [JsonProperty("defaultGameMode")]
    public GameMode DefaultGameMode { get; } = GameMode.Survival;

    [JsonProperty("difficulty")]
    public int Difficulty { get; } = 3;

    [JsonProperty("gameWorld")]
    public string GameWorld { get; } = "Navezgane";

    [JsonProperty("worldSeed")]
    public string WorldSeed { get; } = "PREGEN666";

    [JsonProperty("worldSize")]
    public int WorldSize { get; } = 4096;

    [JsonProperty("blockDamagePlayer")]
    public int BlockDamagePlayer { get; } = 100;

    [JsonProperty("blockDamageAI")]
    public int BlockDamageAI { get; } = 100;

    [JsonProperty("blockDamageAIBloodMoon")]
    public int BlockDamageAIBloodMoon { get; } = 150;

    [JsonProperty("xpMultiplier")]
    public int XPMultiplier { get; } = 100;

    [JsonProperty("playerSafeZoneLevel")]
    public int PlayerSafeZoneLevel { get; } = 5;

    [JsonProperty("playerSafeZoneHours")]
    public int PlayerSafeZoneHours { get; } = 5;

    [JsonProperty("dayLength")]
    public int DayLength { get; } = 60;

    [JsonProperty("dayLightHours")]
    public int DaylightHours { get; } = 8;

    [JsonProperty("dropOnDeath")]
    public DropConfiguration DropOnDeath { get; } = DropConfiguration.All;

    [JsonProperty("dropOnQuit")]
    public DropConfiguration DropOnQuit { get; } = DropConfiguration.Nothing;

    [JsonProperty("bedrollDeadZoneSize")]
    public int BedrollDeadZoneSize { get; } = 15;

    [JsonProperty("bedrollExpiryTime")]
    public int BedrollExpiryTime { get; } = 45;

    [JsonProperty("maxZombieCount")]
    public int MaxZombieCount { get; } = 80;

    [JsonProperty("maxAnimalCount")]
    public int MaxAnimalCount { get; } = 40;

    [JsonProperty("viewDistance")]
    public int ViewDistance { get; } = 10;

    [JsonProperty("zombieSpeed")]
    public AISpeed ZombieSpeed { get; } = AISpeed.Walk;

    [JsonProperty("zombieSpeedNight")]
    public AISpeed ZombieSpeedNight { get; } = AISpeed.Run;

    [JsonProperty("zombieFeralSpeed")]
    public AISpeed ZombieFeralSpeed { get; } = AISpeed.Sprint;

    [JsonProperty("zombieBloodMoonSpeed")]
    public AISpeed ZombieBloodMoonSpeed { get; } = AISpeed.Sprint;

    [JsonProperty("isBloodMoonStatic")]
    public bool IsBloodMoonStatic { get; } = true;

    [JsonProperty("bloodMoonChance")]
    public int BloodMoonChance { get; } = 100;

    [JsonProperty("bloodMoonHourWarning")]
    public int BloodMoonHourWarning { get; } = 8;

    [JsonProperty("bloodMoonEnemyCount")]
    public int BloodMoonEnemyCount { get; } = 8;

    [JsonProperty("lootAbundance")]
    public int LootAbundance { get; } = 100;

    [JsonProperty("lootRespawnDays")]
    public int LootRespawnDays { get; } = 7;

    [JsonProperty("airDropFrequency")]
    public int AirDropFrequency { get; } = 72;

    [JsonProperty("hasAirdropMarker")]
    public bool HasAirDropMarker { get; } = true;

    [JsonProperty("playerSharedKillRange")]
    public int PartySharedKillRange { get; } = 100;

    [JsonProperty("pvpMode")]
    public PVPMode PVPMode { get; } = PVPMode.All;

    [JsonProperty("landClaimCount")]
    public int LandClaimCount { get; } = 1;

    [JsonProperty("landClaimSize")]
    public int LandClaimSize { get; } = 41;

    [JsonProperty("landClaimDeadZone")]
    public int LandClaimDeadZone { get; } = 45;

    [JsonProperty("landClaimExpiryTime")]
    public int LandClaimExpiryTime { get; } = 7;

    [JsonProperty("landClaimDecayMode")]
    public DecayMode LandClaimDecayMode { get; } = DecayMode.FullProtection;

    [JsonProperty("landClaimOnlineDurabilityModifier")]
    public int LandClaimOnlineDurabilityModifier { get; } = 4;

    [JsonProperty("landClaimOfflineDurabilityModifier")]
    public int LandClaimOfflineDurabilityModifier { get; } = 4;

    /// <summary>
    ///   Creates a configuration object from a JSON file
    /// </summary>
    /// <param name="filename"></param>
    /// <returns></returns>
    public static JsonConfiguration FromFile(string filename)
    {
      if (!File.Exists(filename))
      {
        File.WriteAllText(filename, JsonConvert.SerializeObject(new JsonConfiguration()));
      }
      var contents = File.ReadAllText(filename);
      var config = JsonConvert.DeserializeObject<JsonConfiguration>(contents);
      return config;
    }
  }
}

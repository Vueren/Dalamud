﻿using System.Collections.Generic;

using Newtonsoft.Json;

namespace Dalamud.Plugin.Internal.Profiles;

/// <summary>
/// Version 1 of the profile model.
/// </summary>
public class ProfileModelV1 : ProfileModel
{
    /// <summary>
    /// Enum representing the startup policy of a profile.
    /// </summary>
    public enum ProfileStartupPolicy
    {
        /// <summary>
        /// Remember the last state of the profile.
        /// </summary>
        RememberState,

        /// <summary>
        /// Always enable the profile.
        /// </summary>
        AlwaysEnable,

        /// <summary>
        /// Always disable the profile.
        /// </summary>
        AlwaysDisable,
    }

    /// <summary>
    /// Gets the prefix of this version.
    /// </summary>
    public static string SerializedPrefix => "DP1";

    /// <summary>
    /// Gets or sets a value indicating whether this profile should always be enabled at boot.
    /// </summary>
    [JsonProperty("b")]
    [Obsolete("Superseded by StartupPolicy")]
    public bool AlwaysEnableOnBoot { get; set; } = false;

    /// <summary>
    /// Gets or sets the policy to use when Dalamud is loading.
    /// </summary>
    [JsonProperty("p")]
    public ProfileStartupPolicy? StartupPolicy { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this profile is currently enabled.
    /// </summary>
    [JsonProperty("e")]
    public bool IsEnabled { get; set; } = false;

    /// <summary>
    /// Gets or sets a value indicating this profile's color.
    /// </summary>
    [JsonProperty("c")]
    public uint Color { get; set; }

    /// <summary>
    /// Gets or sets the list of plugins in this profile.
    /// </summary>
    public List<ProfileModelV1Plugin> Plugins { get; set; } = new();

    /// <summary>
    /// Class representing a single plugin in a profile.
    /// </summary>
    public class ProfileModelV1Plugin
    {
        /// <summary>
        /// Gets or sets the internal name of the plugin.
        /// </summary>
        public string? InternalName { get; set; }

        /// <summary>
        /// Gets or sets an ID uniquely identifying this specific instance of a plugin.
        /// </summary>
        public Guid WorkingPluginId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this entry is enabled.
        /// </summary>
        public bool IsEnabled { get; set; }
    }
}

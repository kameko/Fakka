﻿
namespace Mochi.Plugins.Types

open System
open System.Collections.Generic
open Akka.Actor

type PluginInfo () =
    member val Name         = String.Empty  with get, set
    member val Company      = String.Empty  with get, set
    member val Version      = Version()     with get, set
    member val Guid         = Guid()        with get, set
    member val Descrption   = String.Empty  with get, set
    member val Published    = DateTime()    with get, set
    member val Author       = String.Empty  with get, set
    member val Copyright    = String.Empty  with get, set
    member val License      = String.Empty  with get, set

type PluginRequirement () =
    member val Name         = String.Empty  with get, set
    member val Company      = String.Empty  with get, set
    member val Version      = Version()     with get, set

type ActorInfo (prop : Props) =
    member val Props = prop with get, set

[<AbstractClass>]
type Plugin () =
    member val Info = PluginInfo() with get, set
    member val LoadDependencies = List<PluginRequirement>() with get, set
    member val ExecDependencies = List<PluginRequirement>() with get, set

    abstract PreLoad : unit -> unit
    abstract LoadSupervisor : unit -> ActorInfo


    (*
    type UnloadReason =
        | UserUnload
        | SystemUnload
        | PluginFault
        | Reloading
    
    type ReportReason =
        | PluginUnloaded of PluginInfo * UnloadReason
        | PluginLoaded of PluginInfo

    type PluginEnvironment = {
        plugins : list<PluginInfo>
    }

    type Plugin = {
        info             : PluginInfo
        loadDependencies : list<PluginRequirement> // plugins that must be loaded before this one can run.
        execDependencies : list<PluginRequirement> // plugins that must be running when this one is.
        supervisor       : Actor<Object> -> unit
        onLoad           : PluginEnvironment -> unit // runs once after all dependencies are resolved
        onReport         : PluginEnvironment -> ReportReason -> unit // runs after every time a plugin is loaded or unloaded
        onUnload         : UnloadReason -> unit
    }
    *)

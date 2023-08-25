using System;
using System.Numerics;

namespace Tarkov_Radar;

public class Player : BasePlayer
{
    public Player(IntPtr address, float direction, string group, Vector3 gunLocation, Vector3 headLocation, string id, Vector3 location, string nickName)
    {
        Address = address;
        Direction = direction;
        Group = group;
        GunLocation = gunLocation;
        HeadLocation = headLocation;
        Id = id;
        Location = location;
        NickName = nickName;
        IsLocalPlayer = false;
    }
}
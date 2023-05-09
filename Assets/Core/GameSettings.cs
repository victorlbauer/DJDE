using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Mode { HOST, CLIENT }
public enum CharacterID { NULL }
public enum StageID { NULL }

namespace Core
{
    public static class s_MatchSettings
    {
        public static Mode mode             = Mode.HOST;
        public static CharacterID character = CharacterID.NULL;
        public static StageID stage         = StageID.NULL;
        public static int nRounds           = 10;
        public static int nPlayers          = 1;
        public static bool bonuses          = false;
        public static bool randomEvents     = false;
    };

    // TODO: mudar para pegar essas informacoes de uma arquivo binario/JSON/Database
    public static class s_GameAssets
    {
        public static readonly Dictionary<CharacterID, string> characters = new Dictionary<CharacterID, string>
        {
            { CharacterID.NULL, "Prefabs/Character_1" }
        };

        public static readonly Dictionary<StageID, string> stages = new Dictionary<StageID, string>
        {
            { StageID.NULL, "Prefabs/Stage_1" }
        };
    }
}

using UnityEngine;

public class CheckPoint_ReadMe : MonoBehaviour
{
    /// Player needs to be refrenced in PlayerRespawnController.cs in player.

   ///When using this, make sure that CheckPoint01 is Refrenced in PlayerRespawnController.cs as the PlayerStartingPoint.
   
   ///Each Object that is a checkpoint needs to follow the NamingConvention; CheckPoint## (## = the checkpoints number. Example; CheckPoint01).
   
   ///PlayerRespawnController.cs needs to be either inn the scene or preferably on a deathplane.
}

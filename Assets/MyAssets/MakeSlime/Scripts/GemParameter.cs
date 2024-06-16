using Assets.MyAssets.InGame.Slimes;
using UnityEngine;

namespace Assets.MyAssets.MakeSlime
{
    /// <summary>
    /// 
    /// </summary>
    public class GemParameter : MonoBehaviour
    {
        [SerializeField]
        private SpecialTypes _specialTypes;

        public SpecialTypes SpecialTypes => _specialTypes;

        [SerializeField]
        private bool _canUse = false;
        
        public bool CanUse => _canUse;

        public void MakeUsable()
        {
            _canUse = true;
        }
    }
}

using Assets.MyAssets.InGame.Slimes;
using UnityEngine;

namespace Assets.MyAssets.MakeSlime
{
    /// <summary>
    /// 
    /// </summary>
    public class MaterialParameter : MonoBehaviour
    {
        [SerializeField]
        private SlimeParameters _slimeParameters;

        public SlimeParameters SlimeParameters => _slimeParameters;

        [SerializeField]
        private bool _canUse = false;
        
        public bool CanUse => _canUse;

        public void MakeUsable()
        {
            _canUse = true;
        }
    }
}
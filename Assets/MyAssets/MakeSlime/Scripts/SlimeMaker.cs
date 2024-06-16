using Assets.MyAssets.InGame.Slimes;
using UnityEngine;

namespace Assets.MyAssets.MakeSlime
{
    /// <summary>
    /// 
    /// </summary>
    public class SlimeMaker : MonoBehaviour
    {
        private SlimeParameters _leftReel;

        private SlimeParameters _centerReel;

        private SlimeParameters _totalParameter;

        private void hoge()
        {
            _totalParameter = new SlimeParameters(_leftReel.Weight +_centerReel.Weight, _leftReel.Size +_centerReel.Size, _leftReel.Viscosity +_centerReel.Viscosity);
        }
        
    }
}
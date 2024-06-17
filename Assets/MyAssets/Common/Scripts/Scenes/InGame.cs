using UnityEngine;
using System.Threading.Tasks;
using Assets.MyAssets.InGame.Slimes;

namespace Assets.MyAssets.Common.Scripts.Scenes
{
    public class InGame : MonoBehaviour
    {
        [SerializeField]
        private float _weight;
        public float Weight => _weight;
        
        [SerializeField]
        private float _size;
        public float Size => _size;
        
        [SerializeField]
        private float _viscosity;
        public float Viscosity => _viscosity;
        
        [SerializeField]
        private SlimeCore _core;
        
        [SerializeField]
        private SpecialTypes _specialTypes;
        public SpecialTypes SpecialTypes => _specialTypes;
        
        public void SetArguments(float weight,float size, float viscosity, SpecialTypes specialTypes)
        {
            //_core.InitializeSlime(new SlimeParameters(weight,size,viscosity), specialTypes);
            _weight = weight;
            _size = size;
            _viscosity = viscosity;
            _specialTypes = specialTypes;
        }
        
        public async void PassMakeSlimeToInGame(string gameData)
        {
            await Task.Delay(3000);
            var nextScene = await SceneLoader.Load<Result>("Result");
            nextScene.SetArguments(gameData);
        }
    }
}

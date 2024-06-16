using System.Collections.Generic;
using Assets.MyAssets.InGame.Slimes;
using Assets.MyAssets.MakeSlime.Inputs;
using UnityEngine;
using R3;
using UnityEngine.UI;

namespace Assets.MyAssets.MakeSlime
{
    public class ReelData : MonoBehaviour
    {
        [SerializeField]
        private List<Vector2> _rectTransforms;
        
        [SerializeField]
        private List<Image> _leftReel = new List<Image>();
        
        [SerializeField]
        private List<SlimeParameters> _leftReelSlimeParameters = new List<SlimeParameters>();
        
        [SerializeField]
        private List<Image> _centerReel = new List<Image>();
        
        [SerializeField]
        private List<SlimeParameters> _centerReelSlimeParameters = new List<SlimeParameters>();
        
        [SerializeField]
        private List<Image> _rightReel = new List<Image>();
        
        [SerializeField]
        private List<SpecialTypes> _rightReelSpecialTypes = new List<SpecialTypes>();

        private int _num;
        
        private IMakeSlimeInputEventProvider _makeSlimeInputEvent;
        
        void Start()
        {
            _num = 0;

            List<List<Image>> imageLists = new List<List<Image>>(){_leftReel,_centerReel,_rightReel};
            List<List<SlimeParameters>> slimeParametersLists = new List<List<SlimeParameters>>(){_leftReelSlimeParameters,_centerReelSlimeParameters};

            _makeSlimeInputEvent = this.gameObject.GetComponent<IMakeSlimeInputEventProvider>();
            
            _makeSlimeInputEvent.UpButton
                .Where(x => x)
                .Subscribe(_ =>
                {
                    if (_num != 2)
                    {
                        RollReelPram(imageLists[_num], true,slimeParametersLists[_num]);
                    }
                    else
                    {
                        RollReelType(imageLists[_num], true, _rightReelSpecialTypes);
                    }
                });
            
            _makeSlimeInputEvent.DownButton
                .Where(x => x)
                .Subscribe(_ =>
                {
                    if (_num != 2)
                    {
                        RollReelPram(imageLists[_num], false,slimeParametersLists[_num]);
                    }
                    else
                    {
                        RollReelType(imageLists[_num], false, _rightReelSpecialTypes);
                    }
                });
            
            _makeSlimeInputEvent.RightButton
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _num++;
                    if (_num > 2)
                    {
                        _num = 0;
                    }
                });
            
            _makeSlimeInputEvent.LeftButton
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _num--;
                    if (_num < 0)
                    {
                        _num = 2;
                    }
                });
        }

        private void RollReelPram(List<Image> reels,bool isUp,List<SlimeParameters> slimeParametersList)
        {
            
            if (isUp)
            {
                reels.Insert(0, reels[2]);
                reels.RemoveAt(3);
                
                slimeParametersList.Insert(0, slimeParametersList[2]);
                slimeParametersList.RemoveAt(3);
            }
            else
            {
                reels.Add(reels[0]);
                reels.RemoveAt(0);
                slimeParametersList.Add(slimeParametersList[0]);
                slimeParametersList.RemoveAt(0);
            }

            
            for(int i = 0; i < 3; i++)
            {
                var anchoredPosition =reels[i].rectTransform.anchoredPosition;
                anchoredPosition.x = reels[i].rectTransform.anchoredPosition.x;
                anchoredPosition.y = _rectTransforms[i].y;

                reels[i].rectTransform.anchoredPosition = anchoredPosition;
                if (i == 0)
                {
                    reels[i].color = new Color(reels[i].color.r, reels[i].color.g, reels[i].color.b, 1);
                }
                else
                {
                    reels[i].color = new Color(reels[i].color.r, reels[i].color.g, reels[i].color.b, 0.3f);
                }
            }
        }
        
        private void RollReelType(List<Image> reels,bool isUp,List<SpecialTypes> specialTypesList)
        {
            if (isUp)
            {
                reels.Insert(0, reels[2]);
                reels.RemoveAt(3);
                specialTypesList.Insert(0, specialTypesList[2]);
                specialTypesList.RemoveAt(3);
            }
            else
            {
                reels.Add(reels[0]);
                specialTypesList.Add(specialTypesList[0]);
                specialTypesList.RemoveAt(0);
            }

            for(int i = 0; i < 3; i++)
            {
                var anchoredPosition =reels[i].rectTransform.anchoredPosition;
                anchoredPosition.x = reels[i].rectTransform.anchoredPosition.x;
                anchoredPosition.y = _rectTransforms[i].y;

                reels[i].rectTransform.anchoredPosition = anchoredPosition;
                if (i == 0)
                {
                    reels[i].color = new Color(reels[i].color.r, reels[i].color.g, reels[i].color.b, 1);
                }
                else
                {
                    reels[i].color = new Color(reels[i].color.r, reels[i].color.g, reels[i].color.b, 0.3f);
                }
            }
        }
        
        public SlimeParameters GetReelSlimeParametersData()
        {
            var left = _leftReelSlimeParameters[0];
            var center = _centerReelSlimeParameters[0];
            return new SlimeParameters(left.Weight + center.Weight,left.Size + center.Size,left.Viscosity + center.Viscosity);
        }
        public SpecialTypes GetReelSpecialTypesData()
        {
            return _rightReelSpecialTypes[0];
        }
    }
}

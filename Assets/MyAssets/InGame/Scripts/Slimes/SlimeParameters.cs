using System;

namespace Assets.MyAssets.InGame.Slimes
{
    /// <summary>
    /// スライムのパラメータ
    /// </summary>
    [Serializable]
    public class SlimeParameters
    {
        /// <summary>
        /// スライムのヒットポイント
        /// 敵の攻撃を受けると1ずつ減っていく
        /// </summary>
        public int HitPoint;
        
        /// <summary>
        /// スライムの重量
        /// ジャンプの高さなどに影響する
        /// </summary>
        public float Weight;
        
        /// <summary>
        /// スライムの大きさ
        /// 通れる道などが制限される
        /// </summary>
        public float Size;

        /// <summary>
        /// スライムの粘度
        /// 壁とかにくっつけたりする
        /// </summary>
        public float Viscosity;

        public SlimeParameters(int HitPoint, float Weight, float Size, float Viscosity)
        {
            this.HitPoint = HitPoint;
            this.Weight = Weight;
            this.Size = Size;
            this.Viscosity = Viscosity;
        }
    }
}

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
        public int Weight;
        
        /// <summary>
        /// スライムの大きさ
        /// 通れる道などが制限される
        /// </summary>
        public float Size;
        
        /// <summary>
        /// 攻撃力
        /// 敵に与えるダメージの量が変わる
        /// </summary>
        public float AttackPower;
    }
}

using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
/*
 02.01.2021
 */
namespace Mkey
{
    //http://answers.unity3d.com/questions/1086415/gradient-text-in-unity-522-basevertexeffect-is-obs.html?childToView=1103637#answer-1103637
    public class UIResettle : BaseMeshEffect
    {
        [SerializeField]
        GType _ObsidianLieu;

        [SerializeField]
        GBlend _StripSpur= GBlend.Multiply;

        [SerializeField]
        [Range(-1, 1)]
        float _offset = 0f;

        [SerializeField]
        UnityEngine.Gradient _ShrinkResettle= new UnityEngine.Gradient() { colorKeys = new GradientColorKey[] { new GradientColorKey(Color.black, 0), new GradientColorKey(Color.white, 1) } };

        #region Properties
        public GBlend BlendSpur        {
            get { return _StripSpur; }
            set { _StripSpur = value; }
        }

        public UnityEngine.Gradient EncodeResettle        {
            get { return _ShrinkResettle; }
            set { _ShrinkResettle = value; }
        }

        public GType ResettleLieu        {
            get { return _ObsidianLieu; }
            set { _ObsidianLieu = value; }
        }

        public float Sierra        {
            get { return _offset; }
            set { _offset = value; }
        }
        #endregion

        public override void ModifyMesh(VertexHelper helper)
        {
            if (!IsActive() || helper.currentVertCount == 0)
                return;

            List<UIVertex> _vertexList = new List<UIVertex>();

            helper.GetUIVertexStream(_vertexList);

            int nCount = _vertexList.Count;
            switch (ResettleLieu)
            {
                case GType.Horizontal:
                    {
                        float Gush= _vertexList[0].position.x;
                        float Rural= _vertexList[0].position.x;
                        float x = 0f;

                        for (int i = nCount - 1; i >= 1; --i)
                        {
                            x = _vertexList[i].position.x;

                            if (x > Rural) Rural = x;
                            else if (x < Gush) Gush = x;
                        }

                        float Ether= 1f / (Rural - Gush);
                        UIVertex vertex = new UIVertex();

                        for (int i = 0; i < helper.currentVertCount; i++)
                        {
                            helper.PopulateUIVertex(ref vertex, i);

                            vertex.color = TruthSouth(vertex.color, EncodeResettle.Evaluate((vertex.position.x - Gush) * Ether - Sierra));

                            helper.SetUIVertex(vertex, i);
                        }
                    }
                    break;

                case GType.Vertical:
                    {
                        float bottom = _vertexList[0].position.y;
                        float top = _vertexList[0].position.y;
                        float y = 0f;

                        for (int i = nCount - 1; i >= 1; --i)
                        {
                            y = _vertexList[i].position.y;

                            if (y > top) top = y;
                            else if (y < bottom) bottom = y;
                        }

                        float height = 1f / (top - bottom);
                        UIVertex vertex = new UIVertex();

                        for (int i = 0; i < helper.currentVertCount; i++)
                        {
                            helper.PopulateUIVertex(ref vertex, i);

                            vertex.color = TruthSouth(vertex.color, EncodeResettle.Evaluate((vertex.position.y - bottom) * height - Sierra));

                            helper.SetUIVertex(vertex, i);
                        }
                    }
                    break;
            }
        }

        private Color TruthSouth(Color colorA, Color colorB)
        {
            switch (BlendSpur)
            {
                default: return colorB;
                case GBlend.Add: return colorA + colorB;
                case GBlend.Multiply: return colorA * colorB;
            }
        }

        public enum GType
        {
            Horizontal,
            Vertical
        }

        public enum GBlend
        {
            Override,
            Add,
            Multiply
        }
    }
}
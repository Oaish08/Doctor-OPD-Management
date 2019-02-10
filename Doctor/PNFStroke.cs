// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports

using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace Doctor
{

    public class CPNFStroke
    {

        const int BRUSH_SAMPLING_CNT = 3;
        public struct StrokeStruct
        {
            public PointF pt;
            public int press;
        }

        public ArrayList m_ItemList = new ArrayList();

        public int m_PenStyle;

        PointF m_ptStart;
        PointF m_ptEnd;

        public int Count()
        {
            return m_ItemList.Count;
        }


        public CPNFStroke()
        {

        }
        public void InsertItem(int idx, PointF pt, int prs)
        {
            StrokeStruct item = new StrokeStruct();
            item.pt = pt;
            item.press = prs;
            m_ItemList.Insert(idx, item);

        }

        public void AddLastItem(int prs)
        {
            StrokeStruct item = new StrokeStruct();
            item.press = prs;
            item.pt = ((StrokeStruct)(m_ItemList[m_ItemList.Count - 1])).pt;
            AddItem(item);
        }
        public void AddItem(PointF pt, int prs)
        {
            StrokeStruct item = new StrokeStruct();
            item.pt = pt;
            item.press = prs;
            AddItem(item);
        }
        public void AddItem(StrokeStruct item)
        {
            m_ItemList.Add(item);
        }


        public void GetItem(int Idx, ref PointF pt, ref int press)
        {
            StrokeStruct sts = (StrokeStruct)m_ItemList[Idx];
            pt = sts.pt;
            press = sts.press;
        }
        public PointF GetItemPoint(int Idx)
        {
            StrokeStruct sts = (StrokeStruct)m_ItemList[Idx];
            return sts.pt;
        }
        public StrokeStruct GetStrokeItem(PointF pt, int press)
        {
            StrokeStruct sts = new StrokeStruct();
            sts.pt = pt;
            sts.press = press;
            return sts;
        }





        public RectangleF DrawLastQuard(Graphics g, Pen pn, int nLastIdx)
        {

            int c = 0;
            if (nLastIdx < 0)
            {
                c = m_ItemList.Count - 1;
            }
            else
            {
                c = nLastIdx + 1;
            }



            //        Console.WriteLine("c=" + c.ToString)
            //       Console.WriteLine("m_item=" + m_ItemList.Count.ToString)

            PointF previousPoint1 = new PointF();
            PointF previousPoint2 = new PointF();
            PointF previousPoint3 = new PointF();


            PointF currentPoint = new PointF();

            StrokeStruct ps = new StrokeStruct();
            if (c == 1)
            {
                ps = (StrokeStruct)m_ItemList[0];
                currentPoint = ps.pt;
                previousPoint1 = currentPoint;
                previousPoint2 = currentPoint;
                previousPoint3 = currentPoint;
            }
            else if (c == 2)
            {
                ps = (StrokeStruct)m_ItemList[1];
                currentPoint = ps.pt;
                ps = (StrokeStruct)m_ItemList[0];
                previousPoint1 = ps.pt;
                previousPoint2 = previousPoint1;
                previousPoint3 = previousPoint2;
            }
            else if (c == 3)
            {
                ps = (StrokeStruct)m_ItemList[2];
                currentPoint = ps.pt;
                ps = (StrokeStruct)m_ItemList[1];
                previousPoint1 = ps.pt;
                ps = (StrokeStruct)m_ItemList[0];
                previousPoint2 = ps.pt;
                previousPoint3 = previousPoint2;
            }
            else
            {
                ps = (StrokeStruct)m_ItemList[c - 1];
                currentPoint = ps.pt;

                ps = (StrokeStruct)m_ItemList[c - 2];
                previousPoint1 = ps.pt;
                ps = (StrokeStruct)m_ItemList[c - 3];
                previousPoint2 = ps.pt;
                ps = (StrokeStruct)m_ItemList[c - 4];
                previousPoint3 = ps.pt;

            }

            PointF mid1 = GetMidPoint(previousPoint2, previousPoint3);
            PointF mid2 = GetMidPoint(previousPoint1, currentPoint);
            double ctrl1X = 0;
            double ctrl1Y = 0;
            double ctrl2X = 0;
            double ctrl2Y = 0;

            GetBezierPoints(previousPoint3.X, previousPoint2.X, previousPoint1.X, currentPoint.X,
                previousPoint3.Y, previousPoint2.Y, previousPoint1.Y, currentPoint.Y, ref
                ctrl1X, ref ctrl2X, ref ctrl1Y, ref ctrl2Y);

            System.Drawing.Drawing2D.GraphicsPath ppath = new System.Drawing.Drawing2D.GraphicsPath();

            ppath.AddBezier(mid1, new PointF((float)ctrl1X, (float)ctrl1Y), new PointF((float)ctrl2X, (float)ctrl2Y), mid2);
            //      Console.WriteLine("drawing...")

            g.DrawPath(pn, ppath);

            RectangleF clipRect = ppath.GetBounds();
            clipRect.Inflate(pn.Width, pn.Width);

            return clipRect;


        }


        public PointF DrawBezierQuard(Graphics g, Pen pn, PointF pt1, PointF pt2, PointF pt3, PointF pt4)
        {
            PointF currentPoint = new PointF();
            PointF previousPoint1 = new PointF();
            PointF previousPoint2 = new PointF();
            PointF previousPoint3 = new PointF();

            if (pt1 != null && pt2 != null && pt3 != null && pt4 != null)
            {
                currentPoint = pt1;
                previousPoint1 = pt2;
                previousPoint2 = pt3;
                previousPoint3 = pt4;
            }
            else if (pt1 != null && pt2 != null && pt3 != null && pt4 == null)
            {
                currentPoint = pt1;
                previousPoint1 = pt2;
                previousPoint2 = pt3;
                previousPoint3 = pt3;

            }
            else if (pt1 != null && pt2 != null && pt3 == null && pt4 == null)
            {
                currentPoint = pt1;
                previousPoint1 = pt2;
                previousPoint2 = pt2;
                previousPoint3 = pt2;
            }
            else if (pt1 != null && pt2 == null && pt3 == null && pt4 == null)
            {
                currentPoint = pt1;
                previousPoint1 = pt1;
                previousPoint2 = pt1;
                previousPoint3 = pt1;

            }
            else if (pt1 == null && pt2 == null && pt3 == null && pt4 == null)
            {
                return PointF.Empty;
            }


            PointF mid1 = GetMidPoint(previousPoint2, previousPoint3);
            PointF mid2 = GetMidPoint(previousPoint1, currentPoint);
            double ctrl1X = 0;
            double ctrl1Y = 0;
            double ctrl2X = 0;
            double ctrl2Y = 0;

            GetBezierPoints(previousPoint3.X, previousPoint2.X, previousPoint1.X, currentPoint.X,
                previousPoint3.Y, previousPoint2.Y, previousPoint1.Y, currentPoint.Y, ref
                ctrl1X, ref ctrl2X, ref ctrl1Y, ref ctrl2Y);

            try
            {
                g.DrawBezier(pn, mid1, new PointF((float)ctrl1X, (float)ctrl1Y), new PointF((float)ctrl2X, (float)ctrl2Y), mid2);
            }
            catch (OutOfMemoryException)
            {
                try
                {
                    pn.Width = 1;
                    g.DrawBezier(pn, mid1, new PointF((float)ctrl1X, (float)ctrl1Y), new PointF((float)ctrl2X, (float)ctrl2Y), mid2);
                }
                catch (OutOfMemoryException)
                {
                }
            }

            return mid2;
        }




        // VBConversions Note: Former VB static variables moved to class level because they aren't supported in C#.
        private double DrawBrushBySpeed_TSave = 0;
        private float DrawBrushBySpeed_thicksave1 = 0;
        private float DrawBrushBySpeed_thicksave2 = 0;

        public void DrawBrushBySpeed(Graphics g, Pen pn, PointF previousPoint1, PointF currentPoint)
        {



            // static double TSave = 0; VBConversions Note: Static variable moved to class level and renamed DrawBrushBySpeed_TSave. Local static variables are not supported in C#.
            // static float thicksave1 = 0; VBConversions Note: Static variable moved to class level and renamed DrawBrushBySpeed_thicksave1. Local static variables are not supported in C#.
            // static float thicksave2 = 0; VBConversions Note: Static variable moved to class level and renamed DrawBrushBySpeed_thicksave2. Local static variables are not supported in C#.


            float cX;
            float cY;

            cX = 0;
            cY = 0;




            Pen pn2 = (Pen)pn.Clone();

            float thick_ = System.Convert.ToSingle(GetLenBetPoints(previousPoint1, currentPoint));
            thick_ = (float)((DrawBrushBySpeed_thicksave1 + DrawBrushBySpeed_thicksave2 + thick_) / 3);

            double T = GetBrushThick(thick_, System.Convert.ToInt32(pn2.Width));
            //        Console.WriteLine("T=" + T.ToString + " W=" + pn2.Width.ToString + " D=" + thick_.ToString)


            int iterCnt = 0;

            if (thick_ > 20)
            {
                iterCnt = 30;
            }
            else if (thick_ > 10)
            {
                iterCnt = 10;
            }
            else if (thick_ > 2)
            {
                iterCnt = 4;
            }
            else
            {
                iterCnt = 2;
            }

            double r = 0;
            double deltaX = (currentPoint.X - previousPoint1.X) / iterCnt;
            double deltaY = (currentPoint.Y - previousPoint1.Y) / iterCnt;
            double deltaT = (T - DrawBrushBySpeed_TSave) / iterCnt;
            float SX = 0;
            float SY = 0;

            float EX = 0;
            float EY = 0;

            for (int i = 1; i <= iterCnt; i++)
            {
                r = DrawBrushBySpeed_TSave + i * deltaT;
                pn2.Width = (float)r;
                SX = (float)(previousPoint1.X + (i - 1) * deltaX);
                SY = (float)(previousPoint1.Y + (i - 1) * deltaY);

                EX = (float)(previousPoint1.X + i * deltaX);
                EY = (float)(previousPoint1.Y + i * deltaY);


                g.DrawLine(pn2, System.Convert.ToInt32(SX), System.Convert.ToInt32(SY), System.Convert.ToInt32(EX), System.Convert.ToInt32(EY));

            }



            DrawBrushBySpeed_TSave = T;
            DrawBrushBySpeed_thicksave2 = DrawBrushBySpeed_thicksave1;
            DrawBrushBySpeed_thicksave1 = thick_;


        }


        public void DrawBrushByPenPressure(Graphics g, Pen pn, int nLastIdx)
        {
            float TSave = 0;
            float TCurrent = 0;
            PointF previousPoint2 = new PointF();
            PointF previousPoint1 = new PointF();
            PointF currentPoint = new PointF();
            StrokeStruct sts = new StrokeStruct();

            if (nLastIdx == -1)
            {
                nLastIdx = m_ItemList.Count - 1;
            }
            else
            {

            }

            if (nLastIdx < 2)
            {
                return;
            }

            sts = (StrokeStruct)m_ItemList[nLastIdx - 1];

            float thick_ = sts.press;
            Pen pn2 = (Pen)pn.Clone();
            if (pn2.Width >= 1)
            {
                TSave = (float)(this.GetBrushThick(thick_, System.Convert.ToInt32(pn2.Width)));
            }
            else
            {
                TSave = (float)(this.GetBrushThick(thick_, 2));
            }

            sts = (StrokeStruct)m_ItemList[nLastIdx];
            thick_ = sts.press;
            if (pn2.Width >= 1)
            {
                TCurrent = (float)(GetBrushThick(thick_, System.Convert.ToInt32(pn2.Width)));
            }
            else
            {
                TCurrent = (float)(GetBrushThick(thick_, 2));
            }

            sts = (StrokeStruct)m_ItemList[nLastIdx];
            currentPoint = sts.pt;
            sts = (StrokeStruct)m_ItemList[nLastIdx - 1];
            previousPoint1 = sts.pt;
            sts = (StrokeStruct)m_ItemList[nLastIdx - 2];
            previousPoint2 = sts.pt;

            PointF origin = new PointF();
            PointF destination = new PointF();
            PointF control = new PointF();


            origin = GetMidPoint(previousPoint2, previousPoint1);
            destination = GetMidPoint(previousPoint1, currentPoint);
            control = previousPoint1;

            int length = System.Convert.ToInt32(Math.Abs(origin.X - destination.X) + Math.Abs(origin.Y - destination.Y));

            int iterCnt = 0;
            var deltaT2 = Math.Abs((short)(TCurrent - TSave));
            if (length > 20)
            {
                iterCnt = 20;
            }
            else if (length > 10)
            {
                iterCnt = 12;
            }
            else if (length > 4)
            {
                if (deltaT2 > 3.0)
                {
                    iterCnt = 20;
                }
                else if (deltaT2 > 2.0)
                {
                    iterCnt = 12;
                }
                else
                {
                    iterCnt = 8;
                }
            }
            else if (length > 2)
            {
                iterCnt = 4;
            }
            else
            {
                iterCnt = 1;
            }

            //        iterCnt = iterCnt * 2

            float r = 0;
            float deltaT = (float)((TCurrent - TSave) / iterCnt);
            float SX = 0;
            float SY = 0;
            float EX = 0;
            float EY = 0;
            float t = (float)(0.0F);
            SX = origin.X;
            SY = origin.Y;

            float inc = (float)(1.0F / iterCnt);

            for (int i = 1; i <= iterCnt; i++)
            {
                t += inc;
                EX = (float)(Math.Pow(1 - t, 2) * origin.X + 2.0 * (1 - t) * t * control.X + t * t * destination.X);
                EY = (float)(Math.Pow(1 - t, 2) * origin.Y + 2.0 * (1 - t) * t * control.Y + t * t * destination.Y);
                r = TSave + i * deltaT;

                pn2.Width = r;
                //Console.WriteLine("bpen - {0} / count - {1}", r, i)
                g.DrawLine(pn2, System.Convert.ToInt32(SX), System.Convert.ToInt32(SY), System.Convert.ToInt32(EX), System.Convert.ToInt32(EY));

                SX = EX;
                SY = EY;
            }

        }



        public double GetBrushThick(double dist, int nThick)
        {

            float minT = (float)(0.1F);
            float maxT = (float)(1.8F);
            float minD = 10;
            float maxD = 100;
            float ret = 0;

            if (nThick > 3)
            {
                maxT = 1;
                minT = (float)(0.01F);
            }

            if (dist < minD)
            {
                ret = minT;
            }
            else if (dist > maxD)
            {
                ret = maxT;
            }
            else
            {
                float r = (float)((maxT - minT) / (maxD - minD));
                ret = (float)(r * dist + minT - r * minD);
            }



            //ret = (maxT + minT) - ret ' for reverse type

            return nThick * ret;



        }


        public string GetInfo()
        {
            string sz = "";
            int i = 0;
            foreach (StrokeStruct st in m_ItemList)
            {
                sz += i.ToString() + " " + st.pt.ToString() + " " + st.press.ToString();
                i++;

            }
            return sz;
        }
        public PointF GetMidPoint(PointF pt1, PointF pt2)
        {
            return new PointF((float)((pt1.X + pt2.X) / 2), (float)((pt1.Y + pt2.Y) / 2));

        }



        public void GetBezierPoints(double x0, double x1, double x2, double x3, double y0, double y1,
            double y2, double y3, ref double ctrl1_x, ref
            double ctrl2_x, ref double ctrl1_y, ref double ctrl2_y)
        {

            //// Assume we need to calculate the control
            //// points between (x1,y1) and (x2,y2).
            //// Then x0,y0 - the previous vertex,
            ////      x3,y3 - the next one.

            double xc1 = (x0 + x1) / 2.0;

            double yc1 = (y0 + y1) / 2.0;
            double xc2 = (x1 + x2) / 2.0;
            double yc2 = (y1 + y2) / 2.0;
            double xc3 = (x2 + x3) / 2.0;
            double yc3 = (y2 + y3) / 2.0;

            double len1 = Math.Sqrt((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0));
            double len2 = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            double len3 = Math.Sqrt((x3 - x2) * (x3 - x2) + (y3 - y2) * (y3 - y2));
            double k1 = 0;
            if (len1 + len2 > 0)
            {
                k1 = len1 / (len1 + len2);
            }
            else
            {
                k1 = 0;
            }

            double k2 = 0;
            if ((len2 + len3) > 0)
            {
                k2 = len2 / (len2 + len3);
            }
            else
            {
                k2 = 0;
            }


            double xm1 = xc1 + (xc2 - xc1) * k1;
            double ym1 = yc1 + (yc2 - yc1) * k1;

            double xm2 = xc2 + (xc3 - xc2) * k2;
            double ym2 = yc2 + (yc3 - yc2) * k2;

            double smooth_value = 0.2;
            //// Resulting control points. Here smooth_value is mentioned
            //// above coefficient K whose value should be in range [0...1].
            ctrl1_x = xm1 + (xc2 - xm1) * smooth_value + x1 - xm1;
            ctrl1_y = ym1 + (yc2 - ym1) * smooth_value + y1 - ym1;

            ctrl2_x = xm2 + (xc2 - xm2) * smooth_value + x2 - xm2;
            ctrl2_y = ym2 + (yc2 - ym2) * smooth_value + y2 - ym2;

        }


        public void SetMinMaXPt(PointF minPt, PointF maxPt)
        {
            double MinX = 0;
            double MaxX = 0;
            double MInY = 0;
            double MaxY = 0;
            MinX = 999999;
            MaxX = 0;
            MInY = 999999;
            MaxY = 0;

            //For Each st As Stroke In e.Strokes
            //        Dim st As Stroke = myInk.Ink.Strokes(myInk.Ink.Strokes.Count - 1)
            foreach (StrokeStruct sts in m_ItemList)
            {
                if (MinX > sts.pt.X)
                {
                    MinX = sts.pt.X;
                }
                if (MaxX < sts.pt.X)
                {
                    MaxX = sts.pt.X;
                }
                if (MInY > sts.pt.Y)
                {
                    MInY = sts.pt.Y;
                }
                if (MaxY < sts.pt.Y)
                {
                    MaxY = sts.pt.Y;
                }

            }
            //Next

            minPt.X = (float)MinX;
            minPt.Y = (float)MInY;
            maxPt.X = (float)MaxX;
            maxPt.Y = (float)MaxY;

            m_ptStart.X = (float)MinX;
            m_ptStart.Y = (float)MInY;
            m_ptEnd.X = (float)MaxX;
            m_ptEnd.Y = (float)MaxY;


        }




        public PointF GetBezierPoint(float t, PointF P0, PointF P1, PointF P2, PointF P3)
        {
            PointF Pt = new PointF();

            Pt.X = (float)((1.0 - t) * (1.0 - t) * (1.0 - t) * P0.X + 3.0 * (1.0 - t) * (1.0 - t) * t * P1.X + 3.0 * (1.0 - t) * t * t * P2.X + t * t * t * P3.X);
            Pt.Y = (float)((1.0 - t) * (1.0 - t) * (1.0 - t) * P0.Y + 3.0 * (1.0 - t) * (1.0 - t) * t * P1.Y + 3.0 * (1.0 - t) * t * t * P2.Y + t * t * t * P3.Y);


            return Pt;
        }

        public object GetLenBetPoints(PointF pt1, PointF pt2)
        {
            return Math.Sqrt((pt1.X - pt2.X) * (pt1.X - pt2.X) + (pt1.Y - pt2.Y) * (pt1.Y - pt2.Y));
        }

    }

}

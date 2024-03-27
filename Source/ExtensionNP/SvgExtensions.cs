using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Svg
{
    public partial struct SvgPoint
    {
        public SvgPoint(SvgPoint svgPoint)
        {
            SvgPoint _newSvgPoint = new SvgPoint(svgPoint.X, svgPoint.Y);
            this = _newSvgPoint;
        }

        public SvgPoint(float x, float y, SvgUnitType type = SvgUnitType.Millimeter)
        {
            SvgUnit _x = new SvgUnit(type, x);
            SvgUnit _y = new SvgUnit(type, y);

            this = new SvgPoint(_x, _y);
        }
    }

    public partial struct SvgUnit
    {
        public static SvgUnit operator +(SvgUnit lhs, float rhs)
        {
            float _nevValue = lhs.Value + rhs;
            SvgUnit _newSvgUnit = new SvgUnit(lhs.Type, _nevValue);

            return _newSvgUnit;
        }

        public static SvgUnit operator -(SvgUnit lhs, float rhs)
        {
            float _nevValue = lhs.Value - rhs;
            SvgUnit _newSvgUnit = new SvgUnit(lhs.Type, _nevValue);

            return _newSvgUnit;
        }

        public SvgUnit Mid(SvgUnit end, SvgUnitType? type = null)
        {
            return Mid(this, end, type);
        }

        public static SvgUnit Mid(SvgUnit start, SvgUnit end, SvgUnitType? type = null)
        {
            float startValue = start.Value;
            float endValue = end.Value;
            float polovinaValue = 0.0f;
            float midValue = 0.0f;

            SvgUnitType newType = SvgUnitType.Millimeter;

            if (type != null)
            {
                newType = (SvgUnitType)type;
            }

            polovinaValue = Math.Abs(startValue - endValue) / 2;

            if (startValue < endValue)
            {
                midValue = startValue + polovinaValue;
            }
            else
            {
                midValue = startValue - polovinaValue;
            }

            SvgUnit _newSvgUnit = new SvgUnit(newType, midValue);

            return _newSvgUnit;
        }
    }

    public sealed partial class SvgElementCollection
    {
        public void AddRange(List<SvgElement> listItems)
        {
            AddRange(listItems.ToArray());  
        }

        public void AddRange(SvgElement[] items)
        {

            foreach (SvgElement item in items)
            {
                this.AddAndForceUniqueID(item, true, true, LogIDChange);
            }
        }


    }
}


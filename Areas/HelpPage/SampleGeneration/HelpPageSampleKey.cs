using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http.Headers;

namespace Comment.Areas.HelpPage
{
 
    public class HelpPageSampleKey
    {
        
        public HelpPageSampleKey(String mType)
        {
            if (mType == null)
            {
                throw new ArgumentNullException("stringType");
            }

            ActionName = String.Empty;
            ControllerName = String.Empty;
            String = mType;
            ParameterNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        }


        public HelpPageSampleKey(String mType, Type type)
            : this(mType)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            ParameterType = type;
        }

        public HelpPageSampleKey(SampleDirection sampleDirection, string controllerName, string actionName, IEnumerable<string> parameterNames)
        {
            if (!Enum.IsDefined(typeof(SampleDirection), sampleDirection))
            {
                throw new InvalidEnumArgumentException("sampleDirection", (int)sampleDirection, typeof(SampleDirection));
            }
            if (controllerName == null)
            {
                throw new ArgumentNullException("controllerName");
            }
            if (actionName == null)
            {
                throw new ArgumentNullException("actionName");
            }
            if (parameterNames == null)
            {
                throw new ArgumentNullException("parameterNames");
            }

            ControllerName = controllerName;
            ActionName = actionName;
            ParameterNames = new HashSet<string>(parameterNames, StringComparer.OrdinalIgnoreCase);
            SampleDirection = sampleDirection;
        }

        public HelpPageSampleKey(String mType, SampleDirection sampleDirection, string controllerName, string actionName, IEnumerable<string> parameterNames)
            : this(sampleDirection, controllerName, actionName, parameterNames)
        {
            if (mType == null)
            {
                throw new ArgumentNullException("mType");
            }

            String = mType;
        }

        public string ControllerName { get; private set; }


        public string ActionName { get; private set; }

        public String mType { get; private set; }

        
        public HashSet<string> ParameterNames { get; private set; }

        public Type ParameterType { get; private set; }

     
        public SampleDirection? SampleDirection { get; private set; }

        public override bool Equals(object obj)
        {
            HelpPageSampleKey otherKey = obj as HelpPageSampleKey;
            if (otherKey == null)
            {
                return false;
            }

            return String.Equals(ControllerName, otherKey.ControllerName, StringComparison.OrdinalIgnoreCase) &&
                String.Equals(ActionName, otherKey.ActionName, StringComparison.OrdinalIgnoreCase) &&
                (mType == otherKey.mType || (mType != null && mType.Equals(otherKey.mType))) &&
                ParameterType == otherKey.ParameterType &&
                SampleDirection == otherKey.SampleDirection &&
                ParameterNames.SetEquals(otherKey.ParameterNames);
        }

        public override int GetHashCode()
        {
            int hashCode = ControllerName.ToUpperInvariant().GetHashCode() ^ ActionName.ToUpperInvariant().GetHashCode();
            if (mType != null)
            {
                hashCode ^= mType.GetHashCode();
            }
            if (SampleDirection != null)
            {
                hashCode ^= SampleDirection.GetHashCode();
            }
            if (ParameterType != null)
            {
                hashCode ^= ParameterType.GetHashCode();
            }
            foreach (string parameterName in ParameterNames)
            {
                hashCode ^= parameterName.ToUpperInvariant().GetHashCode();
            }

            return hashCode;
        }
    }
}

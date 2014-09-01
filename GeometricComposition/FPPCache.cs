using GeometricComposition.GCMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricComposition
{
    public class FPPCache
    {
        // hexagonal prism
        private const int InitialCapacity = 1980;
        private List<GCFacePointPair> cache = null;
        public FPPCache()
        {
            cache = new List<GCFacePointPair>(InitialCapacity);
        }
        public FPPCache(IEnumerable<GCFacePointPair> fpps)
        {
            cache = new List<GCFacePointPair>(fpps);
        }
        public GCFacePointPair this[int index]
        {
            get { return index < cache.Count ? cache[index] : null; }
        }
        public void CopyTo(List<GCFacePointPair> fpps)
        {
            fpps.AddRange(cache);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdcModel.Mappers
{
    public abstract class GeneralMapper< T1, T2 >
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public abstract T1 MapperT2T1( T2 input );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public abstract T2 MapperT1T2(T1 input);

        public abstract IEnumerable<T1> MapperT2T1(IEnumerable<T2> input);

        public abstract IEnumerable<T2> MapperT1T2(IEnumerable<T1> input);
    }
}

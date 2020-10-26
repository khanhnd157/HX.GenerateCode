using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HX.GenerateCode.Model
{
    public class DictionaryDataType
    {
        private static readonly IDictionary<DbType, DataTypeEnum> _dictDataTypes = new Dictionary<DbType, DataTypeEnum>
        {
            {
                DbType.Byte,
                DataTypeEnum.adBoolean
            },
            {
                DbType.Binary,
                DataTypeEnum.adBinary
            },
            {
                DbType.Boolean,
                DataTypeEnum.adBoolean
            },
            {DbType.SByte, DataTypeEnum.adBSTR},
            {
                DbType.Decimal,
                DataTypeEnum.adCurrency
            },
            {
                DbType.Currency,
                DataTypeEnum.adCurrency
            },
            {
                DbType.DateTime,
                DataTypeEnum.adDate
            },
            {
                DbType.Date, DataTypeEnum.adDBDate
            },
            {
                DbType.Time, DataTypeEnum.adDBTime
            },
            {
                DbType.DateTimeOffset,
                DataTypeEnum.adDBTimeStamp
            },
            {
                DbType.Double,
                DataTypeEnum.adDouble
            },
            {DbType.Guid, DataTypeEnum.adGUID},
            {
                DbType.VarNumeric,
                DataTypeEnum.adNumeric
            },
            {
                DbType.Single,
                DataTypeEnum.adSingle
            },
            {
                DbType.Int16,
                DataTypeEnum.adBigInt
            },
            {
                DbType.Int32,
                DataTypeEnum.adBigInt
            },
            {
                DbType.Int64,
                DataTypeEnum.adBigInt
            },
            {
                DbType.UInt64,
                DataTypeEnum.adUnsignedBigInt
            },
            {
                DbType.UInt32,
                DataTypeEnum.adUnsignedInt
            },
            {
                DbType.UInt16,
                DataTypeEnum.adUnsignedSmallInt
            },
            {
                DbType.String,
                DataTypeEnum.adLongVarWChar
            }
        };

        public static string GetDataType(string key)
        {
            DbType dataType;
            if (Enum.TryParse(key, out dataType) && _dictDataTypes.ContainsKey(dataType))
                return _dictDataTypes[dataType].GetHashCode().ToString();

            return key.ToUpper();
        }
    }
}

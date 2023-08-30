using System;

namespace AudioPerformer
{
    /// <summary>
    /// 事件数据
    /// </summary>
    public class EH_TrackBarEventArgs:EventArgs
    {
        /// <summary>
        /// 事件数据
        /// </summary>
        /// <param name="value">值</param>
        public EH_TrackBarEventArgs(object value)
        {
            Value = value;
        }

        /// <summary>
        /// 值
        /// </summary>
        public object Value { get; set; }
    }
}

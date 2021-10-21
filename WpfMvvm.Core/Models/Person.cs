using System;

namespace WpfMvvm.Core
{
    /// <summary>
    /// 사람 데이터 모델
    /// </summary>
    public class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Sex { get; set; }
        public string Description { get; set; }
    }
}

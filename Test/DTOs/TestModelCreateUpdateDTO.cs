using Test.Attributes;

namespace Test.DTOs
{
    public class TestModelCreateUpdateDTO
    {
        [NotNullOrEmpty]
        public string Name { get; set; } = string.Empty;
    }
}

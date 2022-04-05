namespace OptionsPattern.Resources;

public class MedicineResource
{
    public List<Result> result { get; set; }

    public class Result
    {
        public string name { get; set; }
        public int min_price { get; set; }
        public int base_price { get; set; }
        public string selling_unit { get; set; }
    }
}



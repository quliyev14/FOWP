namespace ForOfficialWorkProject.Models
{
    //Product class => {
    //1)prop => name,firma-name,#code,color,age-range or size-range,count,count in packet,price
    public sealed class Product
    {
        public Product() { Id = Guid.NewGuid().ToString(); }

        public Product(string? name, string? firmaName, string? code,
                       string? color, int ageRangeMin, int ageRangeMax,
                       int count, int countInPacket, double price)
        {
            if (ageRangeMin < 0 || ageRangeMin >= 11 &&
                ageRangeMax < 0 || ageRangeMax >= 20 &&
                count < 0 &&
                countInPacket < 0 &&
                price < 0)
                throw new ArgumentException("This have Wrong !!!");
            //Id = Interlocked.Increment(ref ID);
            Id = Guid.NewGuid().ToString();
            Name = name;
            Firma = firmaName;
            Code = code;
            Color = color;
            AgeRangeMin = ageRangeMin;
            AgeRangeMax = ageRangeMax;
            Count = count;
            CountInPacket = countInPacket;
            Price = price;
            dateTime = DateTime.Today;
        }

        public string Id { get; private set; } = default!;
        private DateTime dateTime { get; init; } = default!;
        public string? Name { get; init; } = default!;
        public string? Firma { get; init; } = default;
        public string? Code { get; set; } = default!;
        public string? Color { get; init; } = default!;
        public int AgeRangeMin { get; init; } = default!;
        public int AgeRangeMax { get; init; } = default!;
        public int Count { get; set; } = default!;
        public int CountInPacket { get; set; } = default!;
        public double Price { get; set; } = default!;

        public override string ToString() => $"{Id}. {Name} /{Firma} /Code: {Code} " +
                                             $"/Color: {Color} /Min age: {AgeRangeMin} /Max age: {AgeRangeMax} " +
                                             $"/Count: {Count} /Count in packet: {CountInPacket} /Price: {Price}  " +
                                             $"{dateTime.Day}/{dateTime.Month}/{dateTime.Year} " +
                                             $"{dateTime.Hour}:{dateTime.Minute}:{dateTime.Second}\n";

        //public override string ToString() => $"{Id}. {Name} /{Firma} /Code: {Code} " +
        //                                     $"/Color: {Color} /Min age: {AgeRangeMin} /Max age: {AgeRangeMax} " +
        //                                     $"/Count: {Count} /Count in packet: {CountInPacket} /Price: {Price}  " +
        //                                     $"{dateTime}";
    }
}
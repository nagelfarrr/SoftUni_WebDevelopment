namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Models;
    using CarDealer.DTOs.Import;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Supplier
            this.CreateMap<ImportSupplierDto, Supplier>();

            //Part
            this.CreateMap<ImportPartDto, Part>();
        }
    }
}

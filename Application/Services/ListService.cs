using BienComun.Core.DTOs;
using BienComun.Core.Entities;
using BienComun.Core.Interfaces;
using BienComun.Core.Repository;

namespace BienComun.Application.Services;

public class ListService : IListService
{
    private readonly IListRepository _listRepository;
    private readonly IProductRepository _productRepository;

    public ListService(IListRepository listRepository, IProductRepository productRepository)
    {
        _listRepository = listRepository;
        _productRepository = productRepository;
    }

    public async Task CreateListAsync(CreateListRequest request)
    {
        // Crear la GiftList
        var list = new GiftList
        {
            EventType = request.EventTypeDTO.EventType,
            ListStatus = request.ListStatus,
            CustomEventType = request.EventTypeDTO.CustomEventType,
            GuestCount = request.GuestCount,
            MinContribution = request.MinContribution,
            ListName = request.ListDetails?.ListName,
            EventDate = request.ListDetails?.EventDate,
            CampaignStartDate = request.ListDetails?.CampaignStartDate,
            CampaignStartTime = request.ListDetails?.CampaignStartTime,
            CampaignEndDate = request.ListDetails?.CampaignEndDate,
            CampaignEndTime = request.ListDetails?.CampaignEndTime,
            Location = request.ListDetails?.Location,
            Address = request.ListDetails?.Address,
            Email = request.ConfirmationData?.Email,
            Phone = request.ConfirmationData?.Phone,
            UseMinContribution = request.ConfirmationData?.UseMinContribution ?? false,
            TermsAccepted = request.ConfirmationData?.TermsAccepted ?? false
        };

        // Procesar los productos y sus cantidades
        var products = request.Products.Select(p => new GiftListProduct
        {
            ProductId = p.ProductId,
            Quantity = p.Quantity
        }).ToList();

        list.Products = products;

        await _listRepository.AddAsync(list);
    }

    public async Task<List<GiftListSummaryDto>> GetAllListsAsync()
    {
        var lists = await _listRepository.GetAllAsync();
        return lists.Select(list => new GiftListSummaryDto
        {
            Id = list.Id,
            ListName = list.ListName,
            EventType = (int)list.EventType,
            CustomEventType = list.CustomEventType,
            ListStatus = list.ListStatus,
            GuestCount = list.GuestCount,
            MinContribution = list.MinContribution,
            EventDate = list.EventDate,
            CampaignStartDate = list.CampaignStartDate,
            CampaignStartTime = list.CampaignStartTime,
            CampaignEndDate = list.CampaignEndDate,
            CampaignEndTime = list.CampaignEndTime,
            Location = list.Location,
            Address = list.Address,
            Email = list.Email,
            Phone = list.Phone,
            UseMinContribution = list.UseMinContribution,
            TermsAccepted = list.TermsAccepted,
            ProductCount = list.Products?.Sum(p => p.Quantity) ?? 0
        }).ToList();
    }

    public async Task DeleteListAsync(int id)
    {
        await _listRepository.DeleteAsync(id);
    }

    public async Task<GiftListWithProductsDto?> GetListWithProductsAsync(int id)
    {
        var list = await _listRepository.GetByIdWithProductsAsync(id);
        if (list == null) return null;
        var dto = new GiftListWithProductsDto
        {
            Id = list.Id,
            ListName = list.ListName,
            EventType = (int)list.EventType,
            CustomEventType = list.CustomEventType,
            ListStatus = list.ListStatus,
            GuestCount = list.GuestCount,
            MinContribution = list.MinContribution,
            Address = list.Address,
            Email = list.Email,
            Phone = list.Phone,
            UseMinContribution = list.UseMinContribution,
            TermsAccepted = list.TermsAccepted,
            EventDate = list.EventDate,
            CampaignStartDate = list.CampaignStartDate,
            CampaignStartTime = list.CampaignStartTime,
            CampaignEndDate = list.CampaignEndDate,
            CampaignEndTime = list.CampaignEndTime,
            Location = list.Location,
            Products = list.Products
                .Where(p => p.Product != null)
                .Select(p => new ProductDto
                {
                    Id = p.Product.Id,
                    Name = p.Product.Name,
                    Description = p.Product.Description,
                    Price = p.Product.Price,
                    Supplier = p.Product.Supplier?.Name ?? string.Empty,
                    Category = p.Product.Category?.Name ?? string.Empty,
                    ImageUrl = p.Product.ThumbnailUrl,
                    Quantity = p.Quantity,
                    ReferenceUrl = p.Product.ReferenceUrl,
                    Brand = p.Product.Brand,
                    ThumbnailUrl = p.Product.ThumbnailUrl,
                    ImageUrls = p.Product.Images?.Select(img => img.ImageUrl).ToList() ?? new List<string>()
                }).ToList()
        };
        return dto;
    }
}

using Infrastructure.Context;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AddressManager
{
    private readonly DataContext _context;

    public AddressManager(DataContext context)
    {
        _context = context;
    }

    public async Task<AddressEntity> GetAddressAsync(string UserId)
    {
        var addressEntity = await _context.Address.FirstOrDefaultAsync(x => x.UserId == UserId);
        return addressEntity!;
    }

    public async Task<bool> CreateAddressAsync(AddressEntity entity)
    {
        _context.Address.Add(entity);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> UpdateAddressAsync(AddressEntity entity)
    {
        var existing = await _context.Address.FirstOrDefaultAsync(x => x.UserId == entity.UserId);
        if (existing != null)
        {
            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        
        return false;
    }
}

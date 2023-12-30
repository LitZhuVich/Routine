using Routine.Domain.DtoParameters;
using Routine.Domain.Entities;

namespace Routine.Domain.IRepository;

public interface ICompanyRepository
{
    /// <summary>
    /// 获取所有公司的异步任务
    /// </summary>
    /// <returns>所有公司</returns>
    Task<IEnumerable<Company>> GetCompaniesAsync(CompanyDtoParameters? parameters);

    /// <summary>
    /// 根据公司ID查找公司的异步任务
    /// </summary>
    /// <param name="companyId">公司ID</param>
    /// <returns>找到的公司对象，如果未找到则为null</returns>
    Task<Company?> FindCompanyAsync(Guid companyId);

    /// <summary>
    /// 根据一组公司ID获取公司列表的异步任务
    /// </summary>
    /// <param name="companyIds">公司ID列表</param>
    /// <returns>找到的公司列表</returns>
    Task<IEnumerable<Company>> GetCompaniesAsync(IEnumerable<Guid> companyIds);

    /// <summary>
    /// 创建公司的异步任务
    /// </summary>
    /// <param name="company">要创建的公司对象</param>
    Task CreateCompanyAsync(Company company);

    /// <summary>
    /// 更新公司的异步任务
    /// </summary>
    /// <param name="company">要更新的公司对象</param>
    Task UpdateCompanyAsync(Company company);

    /// <summary>
    /// 删除公司的异步任务
    /// </summary>
    /// <param name="company">要删除的公司对象</param>
    Task DeleteCompanyAsync(Company company);

    /// <summary>
    /// 检查公司是否存在的异步任务
    /// </summary>
    /// <param name="companyId">公司ID</param>
    /// <returns>如果公司存在则为true，否则为false</returns>
    Task<bool> CompanyExistsAsync(Guid companyId);

    /// <summary>
    /// 保存更改的异步任务
    /// </summary>
    /// <returns>保存成功返回 true，否则返回 false</returns>
    Task<bool> SaveAsync();
}

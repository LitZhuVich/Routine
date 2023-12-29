using Routine.Domain.Entities;

namespace Routine.Domain.IRepository;

public interface IEmployeeRepository
{
    /// <summary>
    /// 获取指定公司的所有员工的异步任务
    /// </summary>
    /// <param name="companyId">公司ID</param>
    /// <returns>找到的员工列表</returns>
    Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId);

    /// <summary>
    /// 根据公司ID和员工ID查找员工的异步任务
    /// </summary>
    /// <param name="companyId">公司ID</param>
    /// <param name="employeeId">员工ID</param>
    /// <returns>找到的员工对象，如果未找到则为null</returns>
    Task<Employee?> FindEmployeeAsync(Guid companyId, Guid employeeId);

    /// <summary>
    /// 创建员工的异步任务
    /// </summary>
    /// <param name="companyId">公司ID</param>
    /// <param name="employee">要创建的员工对象</param>
    Task CreateEmployeeAsync(Guid companyId, Employee employee);

    /// <summary>
    /// 更新员工的异步任务
    /// </summary>
    /// <param name="employee">要更新的员工对象</param>
    Task UpdateEmployeeAsync(Employee employee);

    /// <summary>
    /// 删除员工的异步任务
    /// </summary>
    /// <param name="employee">要删除的员工对象</param>
    Task DeleteEmployeeAsync(Employee employee);

    /// <summary>
    /// 保存更改的异步任务
    /// </summary>
    /// <returns>保存成功返回true，否则返回false</returns>
    Task<bool> SaveAsync();
}

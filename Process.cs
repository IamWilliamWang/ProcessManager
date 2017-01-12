using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessManager
{
    class Process
    {
        public int ID { get; set; }
        public String 进程名 { get; set; }
        public DateTime? 启动时间 { get; set; }
        public long? 获得内存大小 { get; set; }
        public long? 获得虚存大小 { get; set; }
        public System.Diagnostics.ProcessPriorityClass? 优先级 { get; set; }
        public int? 优先级参数 { get; set; }
        public IntPtr? 句柄 { get; set; }
        public int? 句柄数 { get; set; }
        public bool? 被终止 { get; set; }
        public String 运行机器名称 { get; set; }
        public String 窗口标题 { get; set; }
        public IntPtr? 最大工作集大小 { get; set; }
        public IntPtr? 最小工作集大小 { get; set; }
        public bool? 拥有抢占权限 { get; set; }
        public bool? 正在响应 { get; set; }
        public TimeSpan? 处理机执行时长 { get; set; }
        public TimeSpan? 获取处理机时长 { get; set; }
        public TimeSpan? 处理机获取和执行时长 { get; set; }

        /*初始化各值，如果权限不足以获取属性，则值其为空然后继续遍历*/
        public Process(System.Diagnostics.Process eachProcess)
        {
            ID = eachProcess.Id;
            try { 优先级参数 = eachProcess.BasePriority; } catch { }
            try { 优先级 = eachProcess.PriorityClass; } catch { }
            try { 句柄 = eachProcess.Handle; } catch { }
            try { 句柄数 = eachProcess.HandleCount; } catch { }
            //try { 被终止 = eachProcess.HasExited; } catch { }
            //try { 运行机器名称 = eachProcess.MachineName; } catch { }
            try { 窗口标题 = eachProcess.MainWindowTitle; } catch { }
            try { 最大工作集大小 = eachProcess.MaxWorkingSet; } catch { }
            try { 最小工作集大小 = eachProcess.MinWorkingSet; } catch { }
            try { 拥有抢占权限 = eachProcess.PriorityBoostEnabled; } catch { }
            try { 处理机执行时长 = eachProcess.PrivilegedProcessorTime; } catch { }
            //try { 获取处理机时长 = eachProcess.UserProcessorTime; } catch { }
            try { 处理机获取和执行时长 = eachProcess.TotalProcessorTime; } catch { }
            try { 进程名 = eachProcess.ProcessName; } catch { }
            try { 正在响应 = eachProcess.Responding; } catch { }
            try { 启动时间 = eachProcess.StartTime; } catch { }
            try { 获得虚存大小 = eachProcess.VirtualMemorySize64/1024; } catch { }
            try { 获得内存大小 = eachProcess.WorkingSet64/1024; } catch { }
        }

    }
}

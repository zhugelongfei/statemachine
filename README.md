# FSM for unity(C#)

# 介绍
有限状态机框架。
此工程为Unity Package的Git包，可通过Unity的PackageManagerWindow导入到需要使用的项目中。

# Unity导入步骤
- 在Unity中点击菜单栏的Window->Package Manager打开PackageManager面板
- 点击Add package from git url
- 复制git工程的地址，粘贴到输入栏，末尾加上#SemVer(e.g. #1.0.0)
- 点击Add

# 应用场景
- 单位状态切换，例如从Idle状态，切换到Run，或其他状态等
- ...

> Note：FSM不允许外部任意地方调用SwitchState的函数。只有State内部可调用SwitchState，以便于后续功能开发维护，能够直观的看到状态是如何切换的
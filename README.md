# C# WPF binding practise

## MVVM开发模式

* 应用MVVM模式开发，数据模型类继承 INotifyPropertyChanged 接口，通过Binding技术实现自动更新
* 自定义 Shape 重写 DependencyProperty DefiningGeometry 属性，实现动态绘图
* 设计自定义的 ICommand，熟悉命令模式
* 了解 RoutedEvent，事件会在控件树上传递，直到被处理

## Canvas

Canvas translate, scale 仅改变显示效果，不影响子元素的坐标信息。

Canvas上移动元素的三种方式：

1. 更新Canvas.Top, Canvas.Left
2. Transform 变换操作
3. 使用GDI+绘制图形

* 编辑少量（少于1000）元素时推荐用Shape，有丰富的事件元素
* 编辑大量元素时推荐用DrawingVisual，需自定义，结合HitTest选择目标
* 需要高性能呈现图形时，建议使用GDI+绘制图形

[绘制图形的三种方法及区别](https://blog.csdn.net/lesshotyang/article/details/8629460)
[使用GDI+绘制图形](https://cxyzjd.com/article/lweiyue/89879028)
[WPF-Samples](https://github.com/microsoft/WPF-Samples/tree/master/Visual%20Layer/DrawingVisual)

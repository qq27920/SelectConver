# SelectConver
更方便快捷的实现WPF自定义转换

1、使用举例

<!--改变可见状态-->
Visibility="{Binding,Converter={StaticResource selectConver},ConverterParameter=true----Collapsed|false----Visible}"


  <!--改变文本-->
Text="{Binding,Converter={StaticResource selectConver},ConverterParameter=true----我被选中了|false----我没被选中|null----选中状态改变我也将被改变}">


2、参数解析
ConverterParameter用法
1、键----值
2、----为分割键和值的符号
3、多个键值对使用|分割

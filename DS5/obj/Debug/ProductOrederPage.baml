   M S B A M L   `   `   `  ����>  :DS5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DS5DS5  5          DS5.ProductOrederPage   5      _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:DS5     5        N� Title$  ProductOrederPage��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��1.1* �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      $��8* �6   �� 5      �� 5      .+�5   
   � $��3��6   $��3��6    5      �� 5      �� 5      �� 5      .+�5      �� -   5        $%��Добавить продукт��5      $��2��60   $��0��6=   6M   �� 5      -   5        $#��Удалить продукт��5      $��2��6/   $��1��6<   6L   �� 5       -   5        $��Получить чек��5       $��2��6,   $��2��69   6I   5!      �� 5#   
   $��Меню��6   $��Center=�6    $��Center=�6=   $��15(�6X   $��0��6f   �� 5$   
   $��
Заказ��6   $��Center=�6!   $��Center=�6>   $��15(�6Y   $��1��6g   �� 5%   
   -   5         ��Name$ change��5%   :   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Оплата��6   $��2��6J   $��1��6W   �� 5&   
   -   5         ��Name$
 many��5&   "   $��Сумма:��6   $��2��60   $��0��6=   &   System.Windows.Controls.DataGrid  5'   
   -   5          Name$ grid_product��5'      $��1��6)   $��0��66      
IsReadOnly .    AutoGenerateColumns .  	   Columns	 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Название��6F      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *name_product+6X     5*      $
 Цена��6?   $
 1.5* 6M    6%   �� *price+6M     5+      $
 Тип продукта��6F   $
 1.5* 6\    6%   �� *product_type+6\   5-        5.   
   -   5        $ grid_pincheck��5.      $��1��6*   $��1��67    .  .  	 5/        50      $
 Название��6F   $ 2* 6X    6%   �� *name_product+6X     51      $
 Цена��6?   $
 1.5* 6M    6%   �� *price+6M     52      $
 Тип продукта��6F   $
 1.5* 6\    6%   �� *product_type+6\   54      55      57      
   M S B A M L   `   `   `  ����>  :DS5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DS5DS5  5          DS5.AccountPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:DS5     5        N� Title$  AccountPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��1* �6   �� 5      $
��0.5* �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   � $��1��6   $��3��6    5      �� 5      �� 5      �� 5       5      �� 5      �� 5      .+�5       �� $��
Логин��6    �� TextAlignment$ Center=�6%   $��0��6<   $��0��6I   $��Center=�6Y   $��Center=�6v   �� 5!      $��Пароль��6   $ Center=�6&   $��0��6=   $��1��6J   $��Center=�6Z   $��Center=�6w   �� 5"      $��Должность��6   $ Center=�6)   $��0��6@   $��2��6M   $��Center=�6]   $��Center=�6z   �� 5#      -   5         ��Name$ login��5#      $��1��6%   $��0��62   $��Center=�6C   �� 5$      -   5        $ password��5$      $��1��6(   $��1��65   $��Center=�6E   �� 5%      -   5         ��Name$ id_role��5%      $��1��6(   $��2��65   $��Center=�6E   5&      �� 5'   
   -   5        $��Добавить��5'      $��2��6$   $��0��61   6A   �� 5(   
   -   5        $��Изменить��5(      $��2��6$   $��1��61   6A   �� 5)   
   -   5        $��Удалить��5)      $��2��6#   $��2��60   6@   &   System.Windows.Controls.DataGrid  5*   
   -   5          Name$ grid_acc��5*      $��0��6%   $��3��62      
IsReadOnly .    AutoGenerateColumns .  	   Columns	 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn
   Header$
 
Логин��6G   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *login_account+6G     5-      $
 Пароль��6I    6%   �� *passord_account+6I     5.      $
 ID��6A    6%   �� *	role_ID+6A   50      52      53      
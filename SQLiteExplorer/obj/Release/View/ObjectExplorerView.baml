   M S B A M L   `   `   `  ���� I  ESQLiteExplorer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SQLiteExplorer.ViewSQLiteExplorer.View  ,    &SQLiteExplorer.View.ObjectExplorerView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:SQLiteExplorer.View     .���� $��2q����	#FF2E5368._�� $��0,0,0,0q�  � RowDefinitions  �� $��18 ��� $��25 ��� $��* �.+�� ���	#FF233980 � ColumnDefinitions �� $��20 ��� $��* �.+��� ���	#FFEAB545$��0q�$	����$��Segoe MDL2 Assets)�$��Center=�$��Center=��� ���	#FFE8D8D8$��1��$��0q�$��Center=�$��SemiBold"�$��Objects Explorer��c� ���	#FFEAB545$
��auto��$��1��.@��� $��2q� � ToolTip$ New database��$��0q�.���� $?��9/SQLiteExplorer;component/Resources/Icons/NewDatabase.png���� $��2q�$ Open database��$��0q����� *OpenDataBaseCMD+.���� $@��:/SQLiteExplorer;component/Resources/Icons/OpenDatabase.png���� $��1q�$	��200��$��22�� �� TextAlignment$ Justify=��� $��2q�$ Search��$��0q�.���� $:��4/SQLiteExplorer;component/Resources/Icons/Search.png���� $��2q�$ Refresh��$��0q����� *
RefreshCMD+.���� $;��5/SQLiteExplorer;component/Resources/Icons/Refresh.png���� $��2��$
��Auto=�$
��Auto=�.���� $��1q����	#FF828ABB._�Q� $��0q�$��0q� Q� 
IsExpanded . ���� *	DataBases+ �� Mode$ TwoWay=�����  �� Orientation$ 
Horizontal=�.+��� $��16��$��16��$:��4/SQLiteExplorer;component/Resources/Icons/folder.png���� $��Center=�	DataBases���� .R�Q� $��0q�����  �� Padding$ 1q�����  �� 
TargetType" ��	 �� Triggers	 P� 
 P� Property
 �@J�IsMouseOver P� Value . . ���  �� Property � �� �� Value
 ���_���  � ��
 �����._��� $��1q�$ 
Horizontal=� � ContextMenu �� .@�m� $��Select�� m� Command �� *	SelectCmd+m� $��Show in Folder�� ��  �� Path$ Parent.OpenDataBaseCMD� m� CommandParameter �� $
 Path�m� $��Import��m� $��Export��m� $��Remove��.+��� $��16��$��16������ " ��.���  � ��$A ;/SQLiteExplorer;component/Resources/Icons/database-icon.png��	 ��  �� Binding �� $ 
IsSelected� �� Value true.a���  � ��$D >/SQLiteExplorer;component/Resources/Icons/dataBaseSelected.png���� $��Center=����� *Name+.@�Q� $��0q�$��0q����� *Tables+���� $ 1q����� " ��	 P� 
 �@J�IsMouseOver . . ���  � ��
 ���_���  � ��
 �����._��� $ 
Horizontal=� �� .@�m� $��Create��m� $��Script To Create��.+��� $��14��$��14��$:��4/SQLiteExplorer;component/Resources/Icons/folder.png���� $��Center=�Tables���� .R�Q� $��0q�$��0q����� $ 1q����� " ��	 P� 
 �@J�IsMouseOver . . ���  � ��
 ���_���  � ��
 �����._��� $ 
Horizontal=�.+��� $��14��$��14��$9��3/SQLiteExplorer;component/Resources/Icons/table.png���� $��Center=����� *Name+.@�Q� $��0q�$��0q����� *	Columns+���� $ 1q����� " ��	 P� 
 �@J�IsMouseOver . . ���  � ��
 ���_���  � ��
 �����._��� $ 
Horizontal=�.+��� $��14��$��14��$:��4/SQLiteExplorer;component/Resources/Icons/folder.png���� $��Center=�	Columns���� .R�Q� ���� $ 1q����� " ��	 P� 
 �@J�IsMouseOver . . ���  � ��
 ���_���  � ��
 �����._��� $ 
Horizontal=�.+��� $��13��$��1q�$��13������ " ��.���  � ��$: 4/SQLiteExplorer;component/Resources/Icons/column.png��	 ��  �� $ IsPrimaryKey� true.a���  � ��$> 8/SQLiteExplorer;component/Resources/Icons/primaryKey.png����  �� $ IsForeignKey� true.a���  � ��$> 8/SQLiteExplorer;component/Resources/Icons/foreginKey.png���� $��Center=����� *Name+�� $��Center=�$��Italic$�$��11(�$��SemiBold"����� *Description+Q� $��0q�$��0q����� *Indexs+���� $ 1q����� " ��	 P� 
 �@J�IsMouseOver . . ���  � ��
 ���_���  � ��
 �����._��� $ 
Horizontal=�.+��� $��14��$��14��$:��4/SQLiteExplorer;component/Resources/Icons/folder.png���� $��Center=�Index���� .R�Q� ���� $ 1q����� " ��	 P� 
 �@J�IsMouseOver . . ���  � ��
 ���_���  � ��
 �����._��� $ 
Horizontal=�.+��� $��12��$��1q�$��12��$:��4/SQLiteExplorer;component/Resources/Icons/Pin-16.png���� $��Center=����� Q� $��0q�$��0q����� *ForeignKeys+���� $ 1q����� " ��	 P� 
 �@J�IsMouseOver . . ���  � ��
 ���_���  � ��
 �����._��� $ 
Horizontal=�.+��� $��14��$��14��$:��4/SQLiteExplorer;component/Resources/Icons/folder.png���� $��Center=�ForeignKeys���� .R�Q� ���� $ 1q����� " ��	 P� 
 �@J�IsMouseOver . . ���  � ��
 ���_���  � ��
 �����._��� $ 
Horizontal=�.+��� $��13��$��13��$>��8/SQLiteExplorer;component/Resources/Icons/foreginKey.png���� $��Center=����� *Name+�� $��Center=�$��Italic$�$��11(�$��SemiBold"����� *Description+Q� $��0q�$��0q����� *Views+���� $ 1q����� " ��	 P� 
 �@J�IsMouseOver . . ���  � ��
 ���_���  � ��
 �����._��� $ 
Horizontal=�.+��� $��14��$��14��$:��4/SQLiteExplorer;component/Resources/Icons/folder.png���� $��Center=�Views���� .R�Q� $��0q�$��0q����� $ 1q����� " ��	 P� 
 �@J�IsMouseOver . . ���  � ��
 ���_���  � ��
 �����._��� $ 
Horizontal=�.+��� $��18��$��18��$8��2/SQLiteExplorer;component/Resources/Icons/view.png���� $��Center=����� *Name+Q� $��0q�$��0q����� *
Triggers+���� $ 1q����� " ��	 P� 
 �@J�IsMouseOver . . ���  � ��
 ���_���  � ��
 �����._��� $ 
Horizontal=�.+��� $��14��$��14��$:��4/SQLiteExplorer;component/Resources/Icons/folder.png���� $��Center=�
Triggers���� .R�Q� $��0q�$��0q����� $ 1q����� " ��	 P� 
 �@J�IsMouseOver . . ���  � ��
 ���_���  � ��
 �����._��� $ 
Horizontal=�.+��� $��15��$��15��$;��5/SQLiteExplorer;component/Resources/Icons/trigger.png���� $��Center=����� *Name+�� $��Center=�$
�� On ��$��Italic$�$��11(�$��SemiBold"��� $��Center=�$��Italic$�$��11(�$��SemiBold"����� *	TableName+
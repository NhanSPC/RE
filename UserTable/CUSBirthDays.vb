Imports pbs.BO.CRM
Imports pbs.Helper


Namespace Data
    Public Class CUSBirthDays
        Inherits BaseUserTable

        Public Overrides ReadOnly Property DataStore As String
            Get
                Return GetType(pbs.BO.CRM.CUS).ToString
            End Get
        End Property

        Public Overrides ReadOnly Property Description As String
            Get
                Return <text>
                           Return all customers having founding date occured in a period of time.
                       </text>.Value
            End Get
        End Property

        Public Overrides ReadOnly Property Group As String
            Get
                Return "CRM"
            End Get
        End Property

        Public Overrides ReadOnly Property Syntax As String
            Get
                Return <text>
                           user table(pbs.BO.Data.CUSBirthdays?FromDate=...&amp;Todate=...)
                       </text>.Value
            End Get
        End Property

        Public Overloads Overrides Function GetTable(pSource As String, pName As String) As DataTable
            Dim args = pbsCmdArgs.NewArgsFromURLLink(pSource)
            Dim dt = GetTable(args)
            dt.TableName = pName

            Return dt
        End Function

        Public Overloads Overrides Function GetTable(Arg As pbsCmdArgs) As DataTable
            Dim fromDate = New pbs.Helper.SmartDate(Arg.GetValueByKey("FromDate", 1)).ToString("MMdd")
            Dim toDate = New pbs.Helper.SmartDate(Arg.GetValueByKey("ToDate", "LM")).ToString("MMdd")

            'filter dictionary
            Dim filter As New Dictionary(Of String, String)
            filter.Add("FromDate", fromDate)
            filter.Add("ToDate", toDate)

            'get infoList
            Dim infoList = (From itm In CUSInfoList.GetInfoList(filter) Where pbs.Helper.SmartDate.Parse(itm.EstablishmentDate).ToString("MMdd") >= fromDate And pbs.Helper.SmartDate.Parse(itm.EstablishmentDate).ToString("MMdd") <= toDate).ToList

            'convert infoList to DataTable
            Dim dt = List2Table.CreateTableFromList(infoList)
            dt.TableName = Me.GetType.ToString

            Return dt
        End Function
    End Class

End Namespace
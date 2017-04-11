Imports pbs.Helper
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports Csla.Validation
Imports pbs.BO.DataAnnotations
Imports pbs.BO.Script
Imports pbs.BO.BusinessRules


Namespace RE

    <Serializable()> _
    <DB(TableName:="pbs_RE_BKG_{XXX}")>
    Public Class BKG
        Inherits Csla.BusinessBase(Of BKG)
        Implements Interfaces.IGenPartObject
        Implements IComparable
        Implements IDocLink



#Region "Property Changed"
        Protected Overrides Sub OnDeserialized(context As Runtime.Serialization.StreamingContext)
            MyBase.OnDeserialized(context)
            AddHandler Me.PropertyChanged, AddressOf BO_PropertyChanged
        End Sub

        Private Sub BO_PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs) Handles Me.PropertyChanged
            'Select Case e.PropertyName

            '    Case "OrderType"
            '        If Not Me.GetOrderTypeInfo.ManualRef Then
            '            Me._orderNo = POH.AutoReference
            '        End If

            '    Case "OrderDate"
            '        If String.IsNullOrEmpty(Me.OrderPrd) Then Me._orderPrd.Text = Me._orderDate.Date.ToSunPeriod

            '    Case "SuppCode"
            '        For Each line In Lines
            '            line._suppCode = Me.SuppCode
            '        Next

            '    Case "ConvCode"
            '        If String.IsNullOrEmpty(Me.ConvCode) Then
            '            _convRate.Float = 0
            '        Else
            '            Dim conv = pbs.BO.LA.CVInfoList.GetConverter(Me.ConvCode, _orderPrd, String.Empty)
            '            If conv IsNot Nothing Then
            '                _convRate.Float = conv.DefaultRate
            '            End If
            '        End If

            '    Case Else

            'End Select

            pbs.BO.Rules.CalculationRules.Calculator(sender, e)
        End Sub
#End Region

#Region " Business Properties and Methods "
        Private _DTB As String = String.Empty


        Private _lineNo As Integer
        <System.ComponentModel.DataObjectField(True, True)> _
        Public ReadOnly Property LineNo() As String
            Get
                Return _lineNo
            End Get
        End Property

        Private _bookingType As String = String.Empty
        <CellInfo(GroupName:="Booking", Tips:="Enter type of booking")>
        Public Property BookingType() As String
            Get
                Return _bookingType
            End Get
            Set(ByVal value As String)
                CanWriteProperty("BookingType", True)
                If value Is Nothing Then value = String.Empty
                If Not _bookingType.Equals(value) Then
                    _bookingType = value
                    PropertyHasChanged("BookingType")
                End If
            End Set
        End Property

        Private _bookingRef As String = String.Empty
        <CellInfo(GroupName:="Booking", Tips:="Enter booking reference number")>
        <Rule(Required:=True)>
        Public Property BookingRef() As String
            Get
                Return _bookingRef
            End Get
            Set(ByVal value As String)
                CanWriteProperty("BookingRef", True)
                If value Is Nothing Then value = String.Empty
                If Not _bookingRef.Equals(value) Then
                    _bookingRef = value
                    PropertyHasChanged("BookingRef")
                End If
            End Set
        End Property

        Private _bookingDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(LinkCode.Calendar, GroupName:="Booking", Tips:="Enter booking date")>
        <Rule(Required:=True)>
        Public Property BookingDate() As String
            Get
                Return _bookingDate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("BookingDate", True)
                If value Is Nothing Then value = String.Empty
                If Not _bookingDate.Equals(value) Then
                    _bookingDate.Text = value
                    PropertyHasChanged("BookingDate")
                End If
            End Set
        End Property

        Private _project As String = String.Empty
        <CellInfo("pbs.BO.RE.PRJ", GroupName:="Project", Tips:="Enter project's name")>
        <Rule(Required:=True)>
        Public Property Project() As String
            Get
                Return _project
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Project", True)
                If value Is Nothing Then value = String.Empty
                If Not _project.Equals(value) Then
                    _project = value
                    PropertyHasChanged("Project")
                End If
            End Set
        End Property

        Private _block As String = String.Empty
        <CellInfo("pbs.BO.RE.BLK", GroupName:="Project", Tips:="Enter block name")>
        Public Property Block() As String
            Get
                Return _block
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Block", True)
                If value Is Nothing Then value = String.Empty
                If Not _block.Equals(value) Then
                    _block = value
                    PropertyHasChanged("Block")
                End If
            End Set
        End Property

        Private _floor As String = String.Empty
        <CellInfo("pbs.BO.RE.FLR", GroupName:="Project", Tips:="Enter floor number")>
        Public Property Floor() As String
            Get
                Return _floor
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Floor", True)
                If value Is Nothing Then value = String.Empty
                If Not _floor.Equals(value) Then
                    _floor = value
                    PropertyHasChanged("Floor")
                End If
            End Set
        End Property

        Private _bookedBy As String = String.Empty
        <CellInfo(GroupName:="Booking", Tips:="Enter booker's name")>
        Public Property BookedBy() As String
            Get
                Return _bookedBy
            End Get
            Set(ByVal value As String)
                CanWriteProperty("BookedBy", True)
                If value Is Nothing Then value = String.Empty
                If Not _bookedBy.Equals(value) Then
                    _bookedBy = value
                    PropertyHasChanged("BookedBy")
                End If
            End Set
        End Property

        Private _leadId As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
        <CellInfo(GroupName:="Contractors", Tips:="Enter Lead ID")>
        Public Property LeadId() As String
            Get
                Return _leadId.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("LeadId", True)
                If value Is Nothing Then value = String.Empty
                If Not _leadId.Equals(value) Then
                    _leadId.Text = value
                    PropertyHasChanged("LeadId")
                End If
            End Set
        End Property

        Private _candidateId As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(GroupName:="Contractors", Tips:="Enter Candidate ID")>
        Public Property CandidateId() As String
            Get
                Return _candidateId.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("CandidateId", True)
                If value Is Nothing Then value = String.Empty
                If Not _candidateId.Equals(value) Then
                    _candidateId.Text = value
                    PropertyHasChanged("CandidateId")
                End If
            End Set
        End Property

        Private _customerCode As String = String.Empty
        <CellInfo(GroupName:="Contractors", Tips:="Enter name of customer")>
        Public Property CustomerCode() As String
            Get
                Return _customerCode
            End Get
            Set(ByVal value As String)
                CanWriteProperty("CustomerCode", True)
                If value Is Nothing Then value = String.Empty
                If Not _customerCode.Equals(value) Then
                    _customerCode = value
                    PropertyHasChanged("CustomerCode")
                End If
            End Set
        End Property

        Private _unitCode As String = String.Empty
        <CellInfo(GroupName:="Payment", Tips:="Enter unit code")>
        Public Property UnitCode() As String
            Get
                Return _unitCode
            End Get
            Set(ByVal value As String)
                CanWriteProperty("UnitCode", True)
                If value Is Nothing Then value = String.Empty
                If Not _unitCode.Equals(value) Then
                    _unitCode = value
                    PropertyHasChanged("UnitCode")
                End If
            End Set
        End Property

        Private _descriptn As String = String.Empty
        <CellInfo(GroupName:="Payment", Tips:="Enter description")>
        Public Property Descriptn() As String
            Get
                Return _descriptn
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Description", True)
                If value Is Nothing Then value = String.Empty
                If Not _descriptn.Equals(value) Then
                    _descriptn = value
                    PropertyHasChanged("Description")
                End If
            End Set
        End Property

        Private _depositAmount As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Payment", Tips:="Deposit amount")>
        Public Property DepositAmount() As String
            Get
                Return _depositAmount.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("DepositAmount", True)
                If value Is Nothing Then value = String.Empty
                If Not _depositAmount.Equals(value) Then
                    _depositAmount.Text = value
                    PropertyHasChanged("DepositAmount")
                End If
            End Set
        End Property

        Private _convCode As String = String.Empty
        <CellInfo(GroupName:="Payment", Tips:="Conversion code")>
        Public Property ConvCode() As String
            Get
                Return _convCode
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ConvCode", True)
                If value Is Nothing Then value = String.Empty
                If Not _convCode.Equals(value) Then
                    _convCode = value
                    PropertyHasChanged("ConvCode")
                End If
            End Set
        End Property

        Private _convRate As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Payment", Tips:="Conversion rate")>
        Public Property ConvRate() As String
            Get
                Return _convRate.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("ConvRate", True)
                If value Is Nothing Then value = String.Empty
                If Not _convRate.Equals(value) Then
                    _convRate.Text = value
                    PropertyHasChanged("ConvRate")
                End If
            End Set
        End Property

        Private _amount As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        <CellInfo(GroupName:="Payment", Tips:="Amount")>
        Public Property Amount() As String
            Get
                Return _amount.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Amount", True)
                If value Is Nothing Then value = String.Empty
                If Not _amount.Equals(value) Then
                    _amount.Text = value
                    PropertyHasChanged("Amount")
                End If
            End Set
        End Property

        Private _paymentRef As String = String.Empty
        <CellInfo(GroupName:="Payment", Tips:="Enter payment reference")>
        Public Property PaymentRef() As String
            Get
                Return _paymentRef
            End Get
            Set(ByVal value As String)
                CanWriteProperty("PaymentRef", True)
                If value Is Nothing Then value = String.Empty
                If Not _paymentRef.Equals(value) Then
                    _paymentRef = value
                    PropertyHasChanged("PaymentRef")
                End If
            End Set
        End Property

        Private _paymentMethod As String = String.Empty
        <CellInfo(GroupName:="Payment", Tips:="Enter method payment was made by")>
        Public Property PaymentMethod() As String
            Get
                Return _paymentMethod
            End Get
            Set(ByVal value As String)
                CanWriteProperty("PaymentMethod", True)
                If value Is Nothing Then value = String.Empty
                If Not _paymentMethod.Equals(value) Then
                    _paymentMethod = value
                    PropertyHasChanged("PaymentMethod")
                End If
            End Set
        End Property

        Private _paidBy As String = String.Empty
        <CellInfo(GroupName:="Payment", Tips:="Enter payer name")>
        Public Property PaidBy() As String
            Get
                Return _paidBy
            End Get
            Set(ByVal value As String)
                CanWriteProperty("PaidBy", True)
                If value Is Nothing Then value = String.Empty
                If Not _paidBy.Equals(value) Then
                    _paidBy = value
                    PropertyHasChanged("PaidBy")
                End If
            End Set
        End Property

        Private _notes As String = String.Empty
        <CellInfo(GroupName:="General", Tips:="Notes")>
        Public Property Notes() As String
            Get
                Return _notes
            End Get
            Set(ByVal value As String)
                CanWriteProperty("Notes", True)
                If value Is Nothing Then value = String.Empty
                If Not _notes.Equals(value) Then
                    _notes = value
                    PropertyHasChanged("Notes")
                End If
            End Set
        End Property

        Private _ncBk0 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property NcBk0() As String
            Get
                Return _ncBk0
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcBk0", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncBk0.Equals(value) Then
                    _ncBk0 = value
                    PropertyHasChanged("NcBk0")
                End If
            End Set
        End Property

        Private _ncBk1 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property NcBk1() As String
            Get
                Return _ncBk1
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcBk1", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncBk1.Equals(value) Then
                    _ncBk1 = value
                    PropertyHasChanged("NcBk1")
                End If
            End Set
        End Property

        Private _ncBk2 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property NcBk2() As String
            Get
                Return _ncBk2
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcBk2", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncBk2.Equals(value) Then
                    _ncBk2 = value
                    PropertyHasChanged("NcBk2")
                End If
            End Set
        End Property

        Private _ncBk3 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property NcBk3() As String
            Get
                Return _ncBk3
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcBk3", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncBk3.Equals(value) Then
                    _ncBk3 = value
                    PropertyHasChanged("NcBk3")
                End If
            End Set
        End Property

        Private _ncBk4 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property NcBk4() As String
            Get
                Return _ncBk4
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcBk4", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncBk4.Equals(value) Then
                    _ncBk4 = value
                    PropertyHasChanged("NcBk4")
                End If
            End Set
        End Property

        Private _ncBk5 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property NcBk5() As String
            Get
                Return _ncBk5
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcBk5", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncBk5.Equals(value) Then
                    _ncBk5 = value
                    PropertyHasChanged("NcBk5")
                End If
            End Set
        End Property

        Private _ncBk6 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property NcBk6() As String
            Get
                Return _ncBk6
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcBk6", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncBk6.Equals(value) Then
                    _ncBk6 = value
                    PropertyHasChanged("NcBk6")
                End If
            End Set
        End Property

        Private _ncBk7 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property NcBk7() As String
            Get
                Return _ncBk7
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcBk7", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncBk7.Equals(value) Then
                    _ncBk7 = value
                    PropertyHasChanged("NcBk7")
                End If
            End Set
        End Property

        Private _ncBk8 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property NcBk8() As String
            Get
                Return _ncBk8
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcBk8", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncBk8.Equals(value) Then
                    _ncBk8 = value
                    PropertyHasChanged("NcBk8")
                End If
            End Set
        End Property

        Private _ncBk9 As String = String.Empty
        <CellInfo(GroupName:="Analysis")>
        Public Property NcBk9() As String
            Get
                Return _ncBk9
            End Get
            Set(ByVal value As String)
                CanWriteProperty("NcBk9", True)
                If value Is Nothing Then value = String.Empty
                If Not _ncBk9.Equals(value) Then
                    _ncBk9 = value
                    PropertyHasChanged("NcBk9")
                End If
            End Set
        End Property

        Private _bphNo As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
        <CellInfo(GroupName:="Input", Tips:="This field is used in batch posting")>
        Public Property BphNo() As String
            Get
                Return _bphNo.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("BphNo", True)
                If value Is Nothing Then value = String.Empty
                If Not _bphNo.Equals(value) Then
                    _bphNo.Text = value
                    PropertyHasChanged("BphNo")
                End If
            End Set
        End Property

        Private _pfdNo As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
        <CellInfo(GroupName:="Input", Tips:="This field is used in batch posting")>
        Public Property PfdNo() As String
            Get
                Return _pfdNo.Text
            End Get
            Set(ByVal value As String)
                CanWriteProperty("PfdNo", True)
                If value Is Nothing Then value = String.Empty
                If Not _pfdNo.Equals(value) Then
                    _pfdNo.Text = value
                    PropertyHasChanged("PfdNo")
                End If
            End Set
        End Property

        Private _updatedBy As String = String.Empty
        <CellInfo(GroupName:="System", Hidden:=True)>
        Public ReadOnly Property UpdatedBy() As String
            Get
                Return _updatedBy
            End Get
        End Property

        Private _updated As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        <CellInfo(GroupName:="System", Hidden:=True)>
        Public ReadOnly Property Updated() As String
            Get
                Return _updated.Text
            End Get
        End Property


        'Get ID
        Protected Overrides Function GetIdValue() As Object
            Return _lineNo
        End Function

        'IComparable
        Public Function CompareTo(ByVal IDObject) As Integer Implements System.IComparable.CompareTo
            Dim ID = IDObject.ToString
            Dim pLineNo As Integer = ID.Trim
            If _lineNo < pLineNo Then Return -1
            If _lineNo > pLineNo Then Return 1
            Return 0
        End Function

#End Region 'Business Properties and Methods

#Region "Validation Rules"

        Private Sub AddSharedCommonRules()
            'Sample simple custom rule
            'ValidationRules.AddRule(AddressOf LDInfo.ContainsValidPeriod, "Period", 1)           

            'Sample dependent property. when check one , check the other as well
            'ValidationRules.AddDependantProperty("AccntCode", "AnalT0")
        End Sub

        Protected Overrides Sub AddBusinessRules()
            AddSharedCommonRules()

            For Each _field As ClassField In ClassSchema(Of BKG)._fieldList
                If _field.Required Then
                    ValidationRules.AddRule(AddressOf Csla.Validation.CommonRules.StringRequired, _field.FieldName, 0)
                End If
                If Not String.IsNullOrEmpty(_field.RegexPattern) Then
                    ValidationRules.AddRule(AddressOf Csla.Validation.CommonRules.RegExMatch, New RegExRuleArgs(_field.FieldName, _field.RegexPattern), 1)
                End If
                '----------using lookup, if no user lookup defined, fallback to predefined by developer----------------------------
                If CATMAPInfoList.ContainsCode(_field) Then
                    ValidationRules.AddRule(AddressOf LKUInfoList.ContainsLiveCode, _field.FieldName, 2)
                    'Else
                    '    Select Case _field.FieldName
                    '        Case "LocType"
                    '            ValidationRules.AddRule(Of LOC, AnalRuleArg)(AddressOf LOOKUPInfoList.ContainsSysCode, New AnalRuleArg(_field.FieldName, SysCats.LocationType))
                    '        Case "Status"
                    '            ValidationRules.AddRule(Of LOC, AnalRuleArg)(AddressOf LOOKUPInfoList.ContainsSysCode, New AnalRuleArg(_field.FieldName, SysCats.LocationStatus))
                    '    End Select
                End If
            Next
            Rules.BusinessRules.RegisterBusinessRules(Me)
            MyBase.AddBusinessRules()
        End Sub
#End Region ' Validation

#Region " Factory Methods "

        Private Sub New()
            _DTB = Context.CurrentBECode
        End Sub

        Public Shared Function BlankBKG() As BKG
            Return New BKG
        End Function

        Public Shared Function NewBKG(ByVal pLineNo As String) As BKG
            'If KeyDuplicated(pLineNo) Then ExceptionThower.BusinessRuleStop(String.Format(ResStr(ResStrConst.NOACCESS), ResStr("BKG")))
            Return DataPortal.Create(Of BKG)(New Criteria(pLineNo))
        End Function

        Public Shared Function NewBO(ByVal ID As String) As BKG
            Dim pLineNo As String = ID.Trim

            Return NewBKG(pLineNo)
        End Function

        Public Shared Function GetBKG(ByVal pLineNo As String) As BKG
            Return DataPortal.Fetch(Of BKG)(New Criteria(pLineNo.ToInteger))
        End Function

        Public Shared Function GetBO(ByVal ID As String) As BKG
            Dim pLineNo As String = ID.Trim

            Return GetBKG(pLineNo)
        End Function

        Public Shared Sub DeleteBKG(ByVal pLineNo As String)
            DataPortal.Delete(New Criteria(pLineNo.ToInteger))
        End Sub

        Public Overrides Function Save() As BKG
            If Not IsDirty Then ExceptionThower.NotDirty(ResStr(ResStrConst.NOTDIRTY))
            If Not IsSavable Then Throw New Csla.Validation.ValidationException(String.Format(ResStr(ResStrConst.INVALID), ResStr("BKG")))

            Me.ApplyEdit()
            BKGInfoList.InvalidateCache()
            Return MyBase.Save()
        End Function

        Public Function CloneBKG(ByVal pLineNo As String) As BKG

            'If BKG.KeyDuplicated(pLineNo) Then ExceptionThower.BusinessRuleStop(ResStr(ResStrConst.CreateAlreadyExists), Me.GetType.ToString.Leaf.Translate)

            Dim cloningBKG As BKG = MyBase.Clone
            cloningBKG._lineNo = 0
            cloningBKG._DTB = Context.CurrentBECode

            'Todo:Remember to reset status of the new object here 
            cloningBKG.MarkNew()
            cloningBKG.ApplyEdit()

            cloningBKG.ValidationRules.CheckRules()

            Return cloningBKG
        End Function

#End Region ' Factory Methods

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Public _lineNo As Integer

            Public Sub New(ByVal pLineNo As String)
                _lineNo = pLineNo.ToInteger

            End Sub
        End Class

        <RunLocal()> _
        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)
            _lineNo = criteria._lineNo

            ValidationRules.CheckRules()
        End Sub

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)
            Using ctx = ConnectionManager.GetManager
                Using cm = ctx.Connection.CreateCommand()
                    cm.CommandType = CommandType.Text
                    cm.CommandText = <SqlText>SELECT * FROM pbs_RE_BKG_<%= _DTB %> WHERE LINE_NO= <%= criteria._lineNo %></SqlText>.Value.Trim

                    Using dr As New SafeDataReader(cm.ExecuteReader)
                        If dr.Read Then
                            FetchObject(dr)
                            MarkOld()
                        End If
                    End Using

                End Using
            End Using
        End Sub

        Private Sub FetchObject(ByVal dr As SafeDataReader)
            _lineNo = dr.GetInt32("LINE_NO")
            _bookingType = dr.GetString("BOOKING_TYPE").TrimEnd
            _bookingRef = dr.GetString("BOOKING_REF").TrimEnd
            _bookingDate.Text = dr.GetInt32("BOOKING_DATE")
            _project = dr.GetString("PROJECT").TrimEnd
            _block = dr.GetString("BLOCK").TrimEnd
            _floor = dr.GetString("FLOOR").TrimEnd
            _bookedBy = dr.GetString("BOOKED_BY").TrimEnd
            _leadId.Text = dr.GetInt32("LEAD_ID")
            _candidateId.Text = dr.GetInt32("CANDIDATE_ID")
            _customerCode = dr.GetString("CUSTOMER_CODE").TrimEnd
            _unitCode = dr.GetString("UNIT_CODE").TrimEnd
            _descriptn = dr.GetString("DESCRIPTION").TrimEnd
            _depositAmount.Text = dr.GetDecimal("DEPOSIT_AMOUNT")
            _convCode = dr.GetString("CONV_CODE").TrimEnd
            _convRate.Text = dr.GetDecimal("CONV_RATE")
            _amount.Text = dr.GetDecimal("AMOUNT")
            _paymentRef = dr.GetString("PAYMENT_REF").TrimEnd
            _paymentMethod = dr.GetString("PAYMENT_METHOD").TrimEnd
            _paidBy = dr.GetString("PAID_BY").TrimEnd
            _notes = dr.GetString("NOTES").TrimEnd
            _ncBk0 = dr.GetString("NC_BK0").TrimEnd
            _ncBk1 = dr.GetString("NC_BK1").TrimEnd
            _ncBk2 = dr.GetString("NC_BK2").TrimEnd
            _ncBk3 = dr.GetString("NC_BK3").TrimEnd
            _ncBk4 = dr.GetString("NC_BK4").TrimEnd
            _ncBk5 = dr.GetString("NC_BK5").TrimEnd
            _ncBk6 = dr.GetString("NC_BK6").TrimEnd
            _ncBk7 = dr.GetString("NC_BK7").TrimEnd
            _ncBk8 = dr.GetString("NC_BK8").TrimEnd
            _ncBk9 = dr.GetString("NC_BK9").TrimEnd
            _bphNo.Text = dr.GetInt32("BPH_NO")
            _pfdNo.Text = dr.GetInt32("PFD_NO")
            _updatedBy = dr.GetString("UPDATED_BY").TrimEnd
            _updated.Text = dr.GetInt32("UPDATED")

        End Sub

        Private Shared _lockObj As New Object
        Protected Overrides Sub DataPortal_Insert()
            SyncLock _lockObj
                Using ctx = ConnectionManager.GetManager
                    Using cm = ctx.Connection.CreateCommand()

                        cm.CommandType = CommandType.StoredProcedure
                        cm.CommandText = String.Format("pbs_RE_BKG_{0}_Insert", _DTB)

                        cm.Parameters.AddWithValue("@LINE_NO", _lineNo).Direction = ParameterDirection.Output
                        AddInsertParameters(cm)
                        cm.ExecuteNonQuery()

                        _lineNo = CInt(cm.Parameters("@LINE_NO").Value)
                    End Using
                End Using
            End SyncLock
        End Sub

        Private Sub AddInsertParameters(ByVal cm As SqlCommand)

            cm.Parameters.AddWithValue("@BOOKING_TYPE", _bookingType.Trim)
            cm.Parameters.AddWithValue("@BOOKING_REF", _bookingRef.Trim)
            cm.Parameters.AddWithValue("@BOOKING_DATE", _bookingDate.DBValue)
            cm.Parameters.AddWithValue("@PROJECT", _project.Trim)
            cm.Parameters.AddWithValue("@BLOCK", _block.Trim)
            cm.Parameters.AddWithValue("@FLOOR", _floor.Trim)
            cm.Parameters.AddWithValue("@BOOKED_BY", _bookedBy.Trim)
            cm.Parameters.AddWithValue("@LEAD_ID", _leadId.DBValue)
            cm.Parameters.AddWithValue("@CANDIDATE_ID", _candidateId.DBValue)
            cm.Parameters.AddWithValue("@CUSTOMER_CODE", _customerCode.Trim)
            cm.Parameters.AddWithValue("@UNIT_CODE", _unitCode.Trim)
            cm.Parameters.AddWithValue("@DESCRIPTION", _descriptn.Trim)
            cm.Parameters.AddWithValue("@DEPOSIT_AMOUNT", _depositAmount.DBValue)
            cm.Parameters.AddWithValue("@CONV_CODE", _convCode.Trim)
            cm.Parameters.AddWithValue("@CONV_RATE", _convRate.DBValue)
            cm.Parameters.AddWithValue("@AMOUNT", _amount.DBValue)
            cm.Parameters.AddWithValue("@PAYMENT_REF", _paymentRef.Trim)
            cm.Parameters.AddWithValue("@PAYMENT_METHOD", _paymentMethod.Trim)
            cm.Parameters.AddWithValue("@PAID_BY", _paidBy.Trim)
            cm.Parameters.AddWithValue("@NOTES", _notes.Trim)
            cm.Parameters.AddWithValue("@NC_BK0", _ncBk0.Trim)
            cm.Parameters.AddWithValue("@NC_BK1", _ncBk1.Trim)
            cm.Parameters.AddWithValue("@NC_BK2", _ncBk2.Trim)
            cm.Parameters.AddWithValue("@NC_BK3", _ncBk3.Trim)
            cm.Parameters.AddWithValue("@NC_BK4", _ncBk4.Trim)
            cm.Parameters.AddWithValue("@NC_BK5", _ncBk5.Trim)
            cm.Parameters.AddWithValue("@NC_BK6", _ncBk6.Trim)
            cm.Parameters.AddWithValue("@NC_BK7", _ncBk7.Trim)
            cm.Parameters.AddWithValue("@NC_BK8", _ncBk8.Trim)
            cm.Parameters.AddWithValue("@NC_BK9", _ncBk9.Trim)
            cm.Parameters.AddWithValue("@BPH_NO", _bphNo.DBValue)
            cm.Parameters.AddWithValue("@PFD_NO", _pfdNo.DBValue)
            cm.Parameters.AddWithValue("@UPDATED_BY", Context.CurrentUserCode)
            cm.Parameters.AddWithValue("@UPDATED", ToDay.ToSunDate)
        End Sub


        Protected Overrides Sub DataPortal_Update()
            SyncLock _lockObj
                Using ctx = ConnectionManager.GetManager
                    Using cm = ctx.Connection.CreateCommand()

                        cm.CommandType = CommandType.StoredProcedure
                        cm.CommandText = String.Format("pbs_RE_BKG_{0}_Update", _DTB)

                        cm.Parameters.AddWithValue("@LINE_NO", _lineNo)
                        AddInsertParameters(cm)
                        cm.ExecuteNonQuery()

                    End Using
                End Using
            End SyncLock
        End Sub

        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_lineNo))
        End Sub

        Private Overloads Sub DataPortal_Delete(ByVal criteria As Criteria)
            Using ctx = ConnectionManager.GetManager
                Using cm = ctx.Connection.CreateCommand()

                    cm.CommandType = CommandType.Text
                    cm.CommandText = <SqlText>DELETE pbs_RE_BKG_<%= _DTB %> WHERE LINE_NO= <%= criteria._lineNo %></SqlText>.Value.Trim
                    cm.ExecuteNonQuery()

                End Using
            End Using

        End Sub

        'Protected Overrides Sub DataPortal_OnDataPortalInvokeComplete(ByVal e As Csla.DataPortalEventArgs)
        '    If Csla.ApplicationContext.ExecutionLocation = ExecutionLocations.Server Then
        '        BKGInfoList.InvalidateCache()
        '    End If
        'End Sub


#End Region 'Data Access                           

#Region " Exists "
        Public Shared Function Exists(ByVal pLineNo As String) As Boolean
            Return BKGInfoList.ContainsCode(pLineNo)
        End Function

        'Public Shared Function KeyDuplicated(ByVal pLineNo As String) As Boolean
        '    Dim SqlText = <SqlText>SELECT COUNT(*) FROM pbs_RE_BKG_DEM WHERE DTB='<%= Context.CurrentBECode %>'  AND LINE_NO= '<%= pLineNo %>'</SqlText>.Value.Trim
        '    Return SQLCommander.GetScalarInteger(SqlText) > 0
        'End Function
#End Region

#Region " IGenpart "

        Public Function CloneBO(ByVal id As String) As Object Implements Interfaces.IGenPartObject.CloneBO
            Return CloneBKG(id)
        End Function

        Public Function getBO1(ByVal id As String) As Object Implements Interfaces.IGenPartObject.GetBO
            Return GetBO(id)
        End Function

        Public Function myCommands() As String() Implements Interfaces.IGenPartObject.myCommands
            Return pbs.Helper.Action.StandardReferenceCommands
        End Function

        Public Function myFullName() As String Implements Interfaces.IGenPartObject.myFullName
            Return GetType(BKG).ToString
        End Function

        Public Function myName() As String Implements Interfaces.IGenPartObject.myName
            Return GetType(BKG).ToString.Leaf
        End Function

        Public Function myQueryList() As IList Implements Interfaces.IGenPartObject.myQueryList
            Return BKGInfoList.GetBKGInfoList
        End Function
#End Region

#Region "IDoclink"
        Public Function Get_DOL_Reference() As String Implements IDocLink.Get_DOL_Reference
            Return String.Format("{0}#{1}", Get_TransType, _lineNo)
        End Function

        Public Function Get_TransType() As String Implements IDocLink.Get_TransType
            Return Me.GetType.ToClassSchemaName.Leaf
        End Function
#End Region

    End Class

End Namespace
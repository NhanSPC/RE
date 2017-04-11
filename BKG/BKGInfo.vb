
Imports pbs.Helper
Imports pbs.Helper.Interfaces
Imports System.Data
Imports Csla
Imports Csla.Data
Imports Csla.Validation

Namespace RE

    <Serializable()> _
    Public Class BKGInfo
        Inherits Csla.ReadOnlyBase(Of BKGInfo)
        Implements IComparable
        Implements IInfo
        Implements IDocLink
        'Implements IInfoStatus


#Region " Business Properties and Methods "


        Private _lineNo As Integer
        Public ReadOnly Property LineNo() As Integer
            Get
                Return _lineNo
            End Get
        End Property

        Private _bookingType As String = String.Empty
        Public ReadOnly Property BookingType() As String
            Get
                Return _bookingType
            End Get
        End Property

        Private _bookingRef As String = String.Empty
        Public ReadOnly Property BookingRef() As String
            Get
                Return _bookingRef
            End Get
        End Property

        Private _bookingDate As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property BookingDate() As String
            Get
                Return _bookingDate.DateViewFormat
            End Get
        End Property

        Private _project As String = String.Empty
        Public ReadOnly Property Project() As String
            Get
                Return _project
            End Get
        End Property

        Private _block As String = String.Empty
        Public ReadOnly Property Block() As String
            Get
                Return _block
            End Get
        End Property

        Private _floor As String = String.Empty
        Public ReadOnly Property Floor() As String
            Get
                Return _floor
            End Get
        End Property

        Private _bookedBy As String = String.Empty
        Public ReadOnly Property BookedBy() As String
            Get
                Return _bookedBy
            End Get
        End Property

        Private _leadId As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
        Public ReadOnly Property LeadId() As String
            Get
                Return _leadId.Text
            End Get
        End Property

        Private _candidateId As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property CandidateId() As String
            Get
                Return _candidateId.Text
            End Get
        End Property

        Private _customerCode As String = String.Empty
        Public ReadOnly Property CustomerCode() As String
            Get
                Return _customerCode
            End Get
        End Property

        Private _unitCode As String = String.Empty
        Public ReadOnly Property UnitCode() As String
            Get
                Return _unitCode
            End Get
        End Property

        Private _descriptn As String = String.Empty
        Public ReadOnly Property Descriptn() As String
            Get
                Return _descriptn
            End Get
        End Property

        Private _depositAmount As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property DepositAmount() As String
            Get
                Return _depositAmount.Text
            End Get
        End Property

        Private _convCode As String = String.Empty
        Public ReadOnly Property ConvCode() As String
            Get
                Return _convCode
            End Get
        End Property

        Private _convRate As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property ConvRate() As String
            Get
                Return _convRate.Text
            End Get
        End Property

        Private _amount As pbs.Helper.SmartFloat = New pbs.Helper.SmartFloat(0)
        Public ReadOnly Property Amount() As String
            Get
                Return _amount.Text
            End Get
        End Property

        Private _paymentRef As String = String.Empty
        Public ReadOnly Property PaymentRef() As String
            Get
                Return _paymentRef
            End Get
        End Property

        Private _paymentMethod As String = String.Empty
        Public ReadOnly Property PaymentMethod() As String
            Get
                Return _paymentMethod
            End Get
        End Property

        Private _paidBy As String = String.Empty
        Public ReadOnly Property PaidBy() As String
            Get
                Return _paidBy
            End Get
        End Property

        Private _notes As String = String.Empty
        Public ReadOnly Property Notes() As String
            Get
                Return _notes
            End Get
        End Property

        Private _ncBk0 As String = String.Empty
        Public ReadOnly Property NcBk0() As String
            Get
                Return _ncBk0
            End Get
        End Property

        Private _ncBk1 As String = String.Empty
        Public ReadOnly Property NcBk1() As String
            Get
                Return _ncBk1
            End Get
        End Property

        Private _ncBk2 As String = String.Empty
        Public ReadOnly Property NcBk2() As String
            Get
                Return _ncBk2
            End Get
        End Property

        Private _ncBk3 As String = String.Empty
        Public ReadOnly Property NcBk3() As String
            Get
                Return _ncBk3
            End Get
        End Property

        Private _ncBk4 As String = String.Empty
        Public ReadOnly Property NcBk4() As String
            Get
                Return _ncBk4
            End Get
        End Property

        Private _ncBk5 As String = String.Empty
        Public ReadOnly Property NcBk5() As String
            Get
                Return _ncBk5
            End Get
        End Property

        Private _ncBk6 As String = String.Empty
        Public ReadOnly Property NcBk6() As String
            Get
                Return _ncBk6
            End Get
        End Property

        Private _ncBk7 As String = String.Empty
        Public ReadOnly Property NcBk7() As String
            Get
                Return _ncBk7
            End Get
        End Property

        Private _ncBk8 As String = String.Empty
        Public ReadOnly Property NcBk8() As String
            Get
                Return _ncBk8
            End Get
        End Property

        Private _ncBk9 As String = String.Empty
        Public ReadOnly Property NcBk9() As String
            Get
                Return _ncBk9
            End Get
        End Property

        Private _bphNo As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
        Public ReadOnly Property BphNo() As String
            Get
                Return _bphNo.Text
            End Get
        End Property

        Private _pfdNo As pbs.Helper.SmartInt32 = New pbs.Helper.SmartInt32(0)
        Public ReadOnly Property PfdNo() As String
            Get
                Return _pfdNo.Text
            End Get
        End Property

        Private _updatedBy As String = String.Empty
        Public ReadOnly Property UpdatedBy() As String
            Get
                Return _updatedBy
            End Get
        End Property

        Private _updated As pbs.Helper.SmartDate = New pbs.Helper.SmartDate()
        Public ReadOnly Property Updated() As String
            Get
                Return _updated.DateViewFormat
            End Get
        End Property

        'Get ID
        Protected Overrides Function GetIdValue() As Object
            Return _lineNo
        End Function

        'IComparable
        Public Function CompareTo(ByVal IDObject) As Integer Implements System.IComparable.CompareTo
            Dim ID = IDObject.ToString
            Dim pLineNo As String = ID.Trim
            If _lineNo < pLineNo Then Return -1
            If _lineNo > pLineNo Then Return 1
            Return 0
        End Function

        Public ReadOnly Property Code As String Implements IInfo.Code
            Get
                Return _lineNo
            End Get
        End Property

        Public ReadOnly Property LookUp As String Implements IInfo.LookUp
            Get
                Return _bookingType
            End Get
        End Property

        Public ReadOnly Property Description As String Implements IInfo.Description
            Get
                Return _bookingRef
            End Get
        End Property


        Public Sub InvalidateCache() Implements IInfo.InvalidateCache
            BKGInfoList.InvalidateCache()
        End Sub


#End Region 'Business Properties and Methods

#Region " Factory Methods "

        Friend Shared Function GetBKGInfo(ByVal dr As SafeDataReader) As BKGInfo
            Return New BKGInfo(dr)
        End Function

        Friend Shared Function EmptyBKGInfo(Optional ByVal pLineNo As String = "") As BKGInfo
            Dim info As BKGInfo = New BKGInfo
            With info
                ._lineNo = pLineNo.ToInteger

            End With
            Return info
        End Function

        Private Sub New(ByVal dr As SafeDataReader)
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

        Private Sub New()
        End Sub


#End Region ' Factory Methods

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
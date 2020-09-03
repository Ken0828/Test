Public Class MathLib

    Public Shared Function NORMDIST(ByVal p As Double, ByVal mean As Double, ByVal stdev As Double) As Double
        Dim ret As Double = -1

        If (p > 0 And p < 1 And mean >= 0 And stdev > 0) Then

            ret = (1 / (stdev * Math.Sqrt(2 * Math.PI))) * Math.Exp((-1 / 2) * (p - mean) * (p - mean) / (stdev * stdev))

        End If

        Return ret

    End Function

    Public Shared Function NORMINV(ByVal p As Double, ByVal mean As Double, ByVal stdev As Double) As Double
        Dim ret As Double = -1
        Dim q, r, val As Double

        If (p < 0 Or p > 1) Then
            Throw New Exception("The probality p must be bigger than 0 and smaller than 1")
        End If

        If (stdev < 0) Then
            Throw New Exception("The standard deviation sigma must be positive")
        End If

        If (p = 0) Then
            Return Double.NegativeInfinity
        End If

        If (p = 1) Then
            Return Double.PositiveInfinity
        End If

        If (stdev = 0) Then
            Return mean
        End If

        q = p - 0.5

        '/* 0.075 <= p <= 0.925 */

        If (Math.Abs(q) <= 0.425) Then
            r = 0.180625 - q * q
            val = q * (((((((r * 2509.0809287301227 + _
                               33430.575583588128) * r + 67265.7709270087) * r + _
                             45921.95393154987) * r + 13731.693765509461) * r + _
                           1971.5909503065513) * r + 133.14166789178438) * r + _
                         3.3871328727963665) / (((((((r * 5226.4952788528544 + _
                        28729.085735721943) * r + 39307.895800092709) * r + _
                        21213.794301586597) * r + 5394.1960214247511) * r + _
                        687.18700749205789) * r + 42.313330701600911) * r + 1)
            '/* closer than 0.075 from {0,1} boundary */
        Else

            '/* r = min(p, 1-p) < 0.075 */
            If (q > 0) Then
                r = 1 - p
            Else
                r = p
            End If

            r = Math.Sqrt(-Math.Log(r))
            '/* r = sqrt(-log(r))  <==>  min(p, 1-p) = exp( - r^2 ) */

            If (r <= 5) Then '/* <==> min(p,1-p) >= exp(-25) ~= 1.3888e-11 */
                r += -1.6
                val = (((((((r * 0.00077454501427834139 + _
                           0.022723844989269184) * r + 0.24178072517745061) * _
                         r + 1.2704582524523684) * r + _
                        3.6478483247632045) * r + 5.769497221460691) * _
                      r + 4.6303378461565456) * r + _
                     1.4234371107496835) _
                / (((((((r * _
                         0.0000000010507500716444169 + 0.00054759380849953455) * _
                        r + 0.015198666563616457) * r + _
                       0.14810397642748008) * r + 0.6897673349851) * _
                     r + 1.6763848301838038) * r + _
                    2.053191626637759) * r + 1)

            Else '/* very close to  0 or 1 */
                r += -5
                val = (((((((r * 0.00000020103343992922881 + _
                           0.000027115555687434876) * r + _
                          0.0012426609473880784) * r + 0.026532189526576124) * _
                        r + 0.29656057182850487) * r + _
                       1.7848265399172913) * r + 5.4637849111641144) * _
                     r + 6.6579046435011033) _
                / (((((((r * _
                         0.0000000000000020442631033899397 + 0.00000014215117583164459) * _
                        r + 0.000018463183175100548) * r + _
                       0.00078686913114561329) * r + 0.014875361290850615) _
                     * r + 0.13692988092273581) * r + _
                    0.599832206555888) * r + 1)
            End If

            If (q < 0.0) Then
                val = -val
            End If

        End If

        Return mean + stdev * val
    End Function


    Public Shared Function NORMSINV(ByVal p As Double) As Double
        Return NORMINV(p, 0, 1)

    End Function

    Public Shared Function AVERAGE(ByVal vals As Double()) As Double
        Dim ret As Double = -1
        Dim sum As Double = 0

        If (vals.Length > 0) Then
            Dim len As Integer = vals.Length
            For i = 0 To vals.Length - 1
                sum += vals(i)
            Next
            ret = sum / len
        End If

        Return ret
    End Function

    Public Shared Function STDEV(ByVal vals As Double()) As Double
        Dim ret As Double = -1
        Dim len As Integer = vals.Length

        If (len > 1) Then
            Dim sum As Double = 0
            Dim X As Double = AVERAGE(vals)
            For i = 0 To len - 1
                sum += (vals(i) - X) * (vals(i) - X)
            Next
            ret = Math.Sqrt(sum / (len - 1))

        End If

        Return ret
    End Function

    Public Shared Function CORREL(ByVal arrX As Double(), ByVal arrY As Double()) As Double
        Dim ret As Double = -1
        If (arrX.Length > 1 And arrY.Length > 1 And arrX.Length = arrY.Length And STDEV(arrX) > 0 And STDEV(arrY) > 0) Then
            Dim Xavg As Double = AVERAGE(arrX)
            Dim Yavg As Double = AVERAGE(arrY)
            Dim Sa As Double = 0
            Dim Sb As Double = 0
            Dim Sc As Double = 0
            For i = 0 To arrX.Length - 1
                Sa += (arrX(i) - Xavg) * (arrY(i) - Yavg)
                Sb += (arrX(i) - Xavg) * (arrX(i) - Xavg)
                Sc += (arrY(i) - Yavg) * (arrY(i) - Yavg)
            Next
            ret = Sa / Math.Sqrt(Sb * Sc)
        End If

        Return ret
    End Function


    Public Shared Function CONFIDENCE(ByVal alpha As Double, ByVal stdev As Double, ByVal samples As Integer) As Double
        Dim ret As Double = -1
        If (alpha > 0 And stdev >= 0 And samples > 1) Then

            ret = (alpha * stdev) / Math.Sqrt(samples)
        End If
        Return ret
    End Function

End Class

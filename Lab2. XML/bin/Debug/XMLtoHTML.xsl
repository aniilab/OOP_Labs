<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0"
   xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="/">
    <html>
      <body>
        <h2>Movies</h2>
        <table border="1">
          <tr>
            <th>Name</th>
            <th>ReleaseDate</th>
            <th>Genre</th>
            <th>RunningTime</th>
            <th>Budget</th>
            <th>Production</th>
            <th>Country</th>
            <th>Watched</th>
          </tr>
          <xsl:for-each select="Movies/Movie">
            <tr>
              <td>
                <xsl:value-of select="@Name"/>
              </td>
              <td>
                <xsl:value-of select="@Country"/>
              </td>
              <td>
                <xsl:value-of select="@ReleaseDate"/>
              </td>
              <td>
                <xsl:value-of select="@Genre"/>
              </td>
              <td>
                <xsl:value-of select="@RunningTime"/>
              </td>
              <td>
                <xsl:value-of select="@Budget"/>
              </td>
              <td>
                <xsl:value-of select="@Production"/>
              </td>
              <td>
                <xsl:value-of select="@Watched"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>

</xsl:stylesheet>
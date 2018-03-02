using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.Reporting.WebForms;

namespace Recursos
{
    /// <summary>
    /// Little wrapper class to seperate report creation from MVC controller
    /// </summary>
    public class ReportUtil
    {
        /// <summary>
        /// Recupera Report Passando Parametros Importantes
        /// </summary>
        /// <param name="path">O objeto path.</param>
        /// <param name="dataSetName">O objeto dataSetName.</param>    
        /// <param name="parameters">O objeto parameters.</param>
        /// <param name="dataSetSource">O dataSetSource.</param>
        /// <param name="reportType">O objeto reportType.</param>
        /// <returns>Report</returns>
        public ReportUtil(string path, string dataSetName, IEnumerable<ReportParameter> parameters, IEnumerable dataSetSource, ReportUtil.Type reportType = ReportUtil.Type.PDF)
        {
            if (!System.IO.File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            this.Path = path;          
            this.DataSetName = dataSetName;
            this.DataSetSource = dataSetSource;
            this.ReportType = reportType;     
            this.Render(parameters);
        }

        /// <summary>
        /// Tipo de Saida de Arquivo.
        /// </summary>
        public enum Type
        {
            /// <summary>
            /// Tipo de Saida de Arquivo PDF.
            /// </summary>
            PDF,

            /// <summary>
            /// Tipo de Saida de Arquivo Word.
            /// </summary>
            WORD,

            /// <summary>
            /// Tipo de Saida de Arquivo Excel.
            /// </summary>            
            EXCEL
        }

        #region ReturnValues

        /// <summary>
        /// Recupera MimeType.
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// Recupera Content.
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// Recupera FileExtension.
        /// </summary>
        public string FileExtension
        {
            get
            {
                string extension;
                switch (this.ReportType)
                {
                    case Type.EXCEL:
                        extension = "xls";
                        break;

                    case Type.WORD:
                        extension = "doc";
                        break;

                    default:
                        extension = "pdf";
                        break;
                }

                return extension;
            }
        }
        #endregion

        #region InternalValues
        /// <summary>
        /// Recupera Path.
        /// </summary>
        private string Path { get; set; }

        /// <summary>
        /// Recupera DataSetName.
        /// </summary>
        private string DataSetName { get; set; }

        /// <summary>
        /// Recupera DataSetSource.
        /// </summary>
        private IEnumerable DataSetSource { get; set; }

        /// <summary>
        /// Recupera ReportType.
        /// </summary>
        private Type ReportType { get; set; }

        #endregion      

        /// <summary>
        /// Recupera Render tamanho do relatorio tambem
        /// </summary>
        /// <param name="parameters">O objeto parameters.</param>
        private void Render(IEnumerable<ReportParameter> parameters)
        {
            LocalReport lr = new LocalReport
            {
                ReportPath = this.Path
            };

            ReportDataSource reportDataSource = new ReportDataSource(this.DataSetName, this.DataSetSource);
            lr.DataSources.Add(reportDataSource);
            lr.EnableExternalImages = true;

            if (parameters != null)
            {
              lr.SetParameters(parameters);
            }                     

            string valorTipo = this.ReportType.ToString();

            string deviceInfo = "<DeviceInfo>" +
                     " <OutputFormat>" + valorTipo + "</OutputFormat>" +
                     "</DeviceInfo>";

            string mimeType;
            string encoding;
            string fileNameExtension;
            Warning[] warnings;
            string[] streams;
            
            this.Content = lr.Render(
                                this.ReportType.ToString(),
                                deviceInfo,
                                out mimeType,
                                out encoding,
                                out fileNameExtension,
                                out streams,
                                out warnings);

            this.MimeType = mimeType;
        }
    }
}
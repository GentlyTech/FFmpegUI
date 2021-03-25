using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaConverter
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            VersionLabel.Text = $"Version {Assembly.GetExecutingAssembly().GetName().Version}";
            AppendRowToLayoutPanel(
                "FFmpeg",
                tableLayoutPanel3,
                "https://www.ffmpeg.org/",
                "FFmpeg is the leading multimedia framework, able to decode, encode, transcode, mux, demux, stream, filter and play pretty much anything that humans and machines have created. It supports the most obscure ancient formats up to the cutting edge. No matter if they were designed by some standards committee, the community or a corporation. It is also highly portable: FFmpeg compiles, runs, and passes our testing infrastructure FATE across Linux, Mac OS X, Microsoft Windows, the BSDs, Solaris, etc. under a wide variety of build environments, machine architectures, and configurations.",
                "LGPLv2.1 license",
                "https://www.gnu.org/licenses/old-licenses/lgpl-2.1.html");

            AppendRowToLayoutPanel(
                "FFmpeg.NET",
                tableLayoutPanel3,
                "https://github.com/cmxl/FFmpeg.NET",
                "FFmpeg.NET provides a straightforward interface for handling media data, making tasks such as converting, slicing and editing both audio and video completely effortless.",
                "MIT License",
                "https://github.com/cmxl/FFmpeg.NET/blob/master/LICENSE.md");
        }

        private void AppendRowToLayoutPanel(string name, TableLayoutPanel layoutPanel, string url = null, string description = null, string licenseName = null, string licenseUrl = null)
        {
            LinkLabel urlLabel = new LinkLabel()
            {
                AutoSize = true,
                Dock = DockStyle.Fill,
                Location = new Point(4, 46),
                Name = "linkLabel" + layoutPanel.RowCount + 1,
                Size = new Size(92, 98),
                Text = name,
                AutoEllipsis = true
            };

            if (url != null)
            {
                urlLabel.Click += (object sender, EventArgs e) => {
                    Process.Start("explorer.exe", url);
                };
            }

            LinkLabel licenseUrlLabel = new LinkLabel()
            {
                AutoSize = true,
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Name = "linkLabel" + layoutPanel.RowCount + 1 + layoutPanel.ColumnCount + 1,
                Size = new Size(400, 400),
                Text = licenseName,
                AutoEllipsis = true
            };

            if (licenseUrl != null)
            {
                licenseUrlLabel.Click += (object sender, EventArgs e) => {
                    Process.Start("explorer.exe", licenseUrl);
                };
            }

            Label descriptionLabel = new Label()
            {
                AutoSize = true,
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Name = "Label" + layoutPanel.RowCount + 1 + layoutPanel.ColumnCount + 1,
                Size = new Size(400, 400),
                Text = description,
                AutoEllipsis = true
            };

            layoutPanel.Controls.Add(urlLabel);
            layoutPanel.Controls.Add(descriptionLabel);
            layoutPanel.Controls.Add(licenseUrlLabel);
        }
    }
}

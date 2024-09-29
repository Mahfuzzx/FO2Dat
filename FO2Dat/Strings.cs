using FO2Dat.Properties;

namespace FO2Dat
{
    public class Strings
    {
        private class Text(string id, string text)
        {
            public string id { get; protected set; } = id;
            public string text { get; protected set; } = text;
        }

        private readonly List<Text> texts = [];

        public const int turkish = 1055;
        public const int english = 1033;

        public string? newFile { get; protected set; }
        public string? changeLanguageRestartPrompt { get; protected set; }
        public string? applicationExitPrompt { get; protected set; }
        public string? fileOpenErrorMessage { get; protected set; }
        public string? fileNewErrorMessage { get; protected set; }
        public string? warning { get; protected set; }
        public string? error { get; protected set; }
        public string? total { get; protected set; }
        public string? name { get; protected set; }
        public string? type { get; protected set; }
        public string? fileSize { get; protected set; }
        public string? realSize { get; protected set; }
        public string? packedSize { get; protected set; }
        public string? offset { get; protected set; }
        public string? folder { get; protected set; }
        public string? file { get; protected set; }
        public string? item { get; protected set; }
        public string? shown { get; protected set; }
        public string? selected { get; protected set; }
        public string? package { get; protected set; }
        public string? sLer { get; protected set; }
        public string? sLar { get; protected set; }
        public string? compressed { get; protected set; }
        public string? uncompressed { get; protected set; }

        public Strings() => switchTo(Settings.Default.languageLCID);

        public void switchTo(int LCID)
        {
            switch (LCID)
            {
                case turkish:
                    file = "Dosya";
                    item = "nesne";
                    shown = "gösteriliyor";
                    selected = "seçildi";
                    package = "Paket";
                    newFile = "Yeni Paket";
                    total = "Toplam";
                    compressed = "Sıkıştırılmış";
                    uncompressed = "Sıkıştırılmamış";
                    folder = "Klasör";
                    sLer = "ler";
                    sLar = "lar";
                    name = "Ad";
                    type = "Tür";
                    fileSize = "Paketin Boyutu";
                    realSize = "Gerçek Boyut";
                    packedSize = "Paket Boyutu";
                    offset = "Offset";
                    warning = "Uyarı";
                    error = "Hata";
                    changeLanguageRestartPrompt = "Dil değişikliğini uygulayabilmek için programın yeniden başlatılması gerekiyor. Devam etmek istiyor musunuz?";
                    applicationExitPrompt = "Paketin hala kaydedilmesi gerekiyor. Yine de çıkmak istiyor musunuz?";
                    fileOpenErrorMessage = "Paket açılamadı! Formatı geçersiz veya paket bozulmuş.";
                    fileNewErrorMessage = "Beklenmedik hata!";
                    texts.Add(new Text("mnuFile", "Paket"));
                    texts.Add(new Text("mnuFileNew", "Yeni..."));
                    texts.Add(new Text("mnuFileOpen", "Aç..."));
                    texts.Add(new Text("mnuFileClose", "Kapat"));
                    texts.Add(new Text("mnuFileCompress", "Sıkıştır..."));
                    texts.Add(new Text("mnuFileQuit", "Çıkış"));
                    texts.Add(new Text("mnuView", "Görünüm"));
                    texts.Add(new Text("mnuViewLargeIcon", "Büyük Simgeler"));
                    texts.Add(new Text("mnuViewSmallIcon", "Küçük Simgeler"));
                    texts.Add(new Text("mnuViewList", "Liste"));
                    texts.Add(new Text("mnuViewDetails", "Ayrıntılar"));
                    texts.Add(new Text("mnuViewTile", "Döşeme"));
                    texts.Add(new Text("mnuViewShowGroups", "Grupları Göster"));
                    texts.Add(new Text("mnuFileExtractAll", "Tümünü Çıkar..."));
                    texts.Add(new Text("mnuFileExtractSelection", "Seçimi Çıkar..."));
                    texts.Add(new Text("btnNew", "Yeni"));
                    texts.Add(new Text("btnOpen", "Aç"));
                    texts.Add(new Text("btnClose", "Kapat"));
                    texts.Add(new Text("btnCompress", "Sıkıştır"));
                    texts.Add(new Text("btnViewLargeIcons", "Büyük Simgeler"));
                    texts.Add(new Text("btnViewSmallIcons", "Küçük Simgeler"));
                    texts.Add(new Text("btnViewList", "Liste"));
                    texts.Add(new Text("btnViewDetails", "Ayrıntılar"));
                    texts.Add(new Text("btnViewTile", "Döşeme"));
                    texts.Add(new Text("btnViewGroups", "Grupları Göster"));
                    texts.Add(new Text("btnExtractAll", "Tümünü Çıkar"));
                    texts.Add(new Text("btnExtractSelection", "Seçimi Çıkar"));
                    texts.Add(new Text("btnUpOneLevel", "Yukarı"));
                    texts.Add(new Text("mnuLanguage", "Dil"));
                    break;
                default:
                case english:
                    file = "File";
                    item = "item";
                    shown = "shown";
                    selected = "selected";
                    package = "Package";
                    newFile = "New Package";
                    total = "Total";
                    compressed = "Compressed";
                    uncompressed = "Uncompressed";
                    folder = "Folder";
                    sLer = "s";
                    sLar = "s";
                    name = "Name";
                    type = "Type";
                    fileSize = "Package Size";
                    realSize = "Real Size";
                    packedSize = "Packed Size";
                    offset = "Offset";
                    warning = "Warning";
                    error = "Error";
                    changeLanguageRestartPrompt = "The program needs to be restarted to apply the language change. Do you want to continue?";
                    applicationExitPrompt = "The package still needs to be saved. Do you want to exit anyway?";
                    fileOpenErrorMessage = "The package could not be opened! The format is invalid or the package is corrupt.";
                    fileNewErrorMessage = "Unexpected error!";
                    texts.Add(new Text("mnuFile", "Package"));
                    texts.Add(new Text("mnuFileNew", "New..."));
                    texts.Add(new Text("mnuFileOpen", "Open..."));
                    texts.Add(new Text("mnuFileClose", "Close"));
                    texts.Add(new Text("mnuFileCompress", "Compress..."));
                    texts.Add(new Text("mnuFileQuit", "Exit"));
                    texts.Add(new Text("mnuView", "View"));
                    texts.Add(new Text("mnuViewLargeIcon", "Large Icons"));
                    texts.Add(new Text("mnuViewSmallIcon", "Small Icons"));
                    texts.Add(new Text("mnuViewList", "List"));
                    texts.Add(new Text("mnuViewDetails", "Details"));
                    texts.Add(new Text("mnuViewTile", "Tile"));
                    texts.Add(new Text("mnuViewShowGroups", "Show Groups"));
                    texts.Add(new Text("mnuFileExtractAll", "Extract All..."));
                    texts.Add(new Text("mnuFileExtractSelection", "Extract Selection..."));
                    texts.Add(new Text("btnNew", "New"));
                    texts.Add(new Text("btnOpen", "Open"));
                    texts.Add(new Text("btnClose", "Close"));
                    texts.Add(new Text("btnCompress", "Compress"));
                    texts.Add(new Text("btnViewLargeIcons", "Large Icons"));
                    texts.Add(new Text("btnViewSmallIcons", "Small Icons"));
                    texts.Add(new Text("btnViewList", "List"));
                    texts.Add(new Text("btnViewDetails", "Details"));
                    texts.Add(new Text("btnViewTile", "Tile"));
                    texts.Add(new Text("btnViewGroups", "Show Groups"));
                    texts.Add(new Text("btnExtractAll", "Extract All"));
                    texts.Add(new Text("btnExtractSelection", "Extract Selection"));
                    texts.Add(new Text("btnUpOneLevel", "Up"));
                    texts.Add(new Text("mnuLanguage", "Language"));
                    break;
            }
        }

        public string this[string id] => texts.Find(x => x.id == id)?.text ?? "";
    }
}

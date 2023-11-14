using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovKzServices;

public partial class QazStatClient
{
    public const int EconomicalActivityDictionary = 4855;
    public const int CompanySizeDictionary = 15;
    public const int OwnershipFormDictionary = 17;
    public const int OrganizationalOwnershipFormDictionary = 996;
    public const int RegionsDictionary = 213;

    public Task<ICollection<TreeItem>> GetStatDataAsync(int dictId, string lang, bool? withParents, CancellationToken cancellationToken = default)
    {
        return GetStatDataAsync(dictId, "#", lang, withParents, cancellationToken);
    }

    public Task<ICollection<TreeItem>> GetStatDataAsync(int dictId, int parent, string lang, bool? withParents, CancellationToken cancellationToken = default)
    {
        return GetStatDataAsync(dictId, parent.ToString(), lang, withParents, cancellationToken);
    }

    public string GetFileDownloadUrl(string bucket, string fileGuid)
    {
        return $"https://stat.gov.kz/api/sbr/download?bucket={bucket}&guid={fileGuid}";
    }
}
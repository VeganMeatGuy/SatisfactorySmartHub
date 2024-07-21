using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Interfaces.Application.Services;

/// <summary>
/// The corporation service interface.
/// </summary>
public interface ICorporationService
{
    /// <summary>
    /// Returns a empty corporation model wich is named after <paramref name="corporationName"/> parameter.
    /// </summary>
    /// <param name="corporationName">The name for the corporation.</param>
    /// <returns><see cref="CorporationModel"/></returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentException"/>
    CorporationModel GetNewCorporation(string corporationName);

    /// <summary>
    /// Returns a corporation model which is loaded from a .json file.
    /// </summary>
    /// <param name="filePath">The path of the .json file.</param>
    /// <returns><see cref="CorporationModel"/></returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentException"/>
    CorporationModel GetCorporationFromFile(string filePath);

    /// <summary>
    /// Returns true if corporation model is succesfully saved.
    /// </summary>
    /// <param name="corporation">The corporation model which is saved.</param>
    /// <param name="overwriteFile">If true, an existing corporation is overwritten. If false, the corporation gets an unique name.</param>
    /// <exception cref="ArgumentNullException"/>
    bool SaveCorporation(CorporationModel corporation, bool overwriteFile);

    /// <summary>
    /// Returns true if corporation model is succesfully exported.
    /// </summary>
    /// <param name="corporation">The corporation model which is exported.</param>
    /// <param name="filePath">The file path where the corporation is exported to.</param>
    /// <exception cref="ArgumentNullException"/>
    bool ExportCorporation(CorporationModel corporation, string filePath);

    /// <summary>
    /// Returns a list of names from available saves of corporations.
    /// </summary>
    /// <returns>A list of file names.</returns>
    ICollection<string> GetSaveFiles();
}

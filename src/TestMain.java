import shared.Result;

public class TestMain {
    public static void main(String[] args) {

    }

    /*
    private Link createShareV1(OwnerId owner, List<FileId> files) {
        var shareOwner = loadShareOwner(owner);
        var sharedFiles = loadSharedFiles(files);
        var share = new Share(shareOwner, sharedFiles);

        share.protect(password);

        save(share);

        return share.getLink();
    }

    private Link createShareV2(OwnerId owner, List<FileId> files) {
        var owner = loadOwner(owner);
        var share = owner.createShare(files);

        share.protect(password);

        save(share);

        return share.getLink();
    }

    private void includeFileInShare(ShareId share, FileId file) {
        var contributor = Contributor.FromUser(currentUser());
        var fileOwner = loadOwner(currentUser());
        var share = load(shareId);

        share.IncludeFile(contributor, fileOwner.ShareFile(fileId));

        save(share);
    }

    private void removeFileFromShare(ShareId shareId, FileId file) {
        var contributor = Contributor.FromUser(currentUser());
        var share = load(shareId);

        share.ExcludeFile(contributor, fileId);

        save(share);
    }

    private PublicShareInfo accessShare(ShareId shareId, Key key) {
        var visitor = Visitor.From(currentVisitor());
        var share = load(shareId);

        share.unlock(visitor, key);

        return share.PublicInfo(key);
    }

    private FileStream DownloadFile(ShareId shareId, FileId fileId, Key key) {
        try
        (Transaction transaction = db.CreateTransaction())
        {
            var share = load(shareId);
            var file = share.getFile(fileId, key);

            return fileStorage.stream(file);
        }
    }

    private FileStream DownloadShare(ShareId shareId, Key key) {
        var share = load(shareId);
        var archive = share.getArchiveOfAllFiles();

        return fileStorage.stream(archive);
    }

    // Open link - GET /share/id
    // --> return name, list of files / 401
    // POST /share/id/authentication -> return token (has expire time)


    // GET /
    //  -> GET /files
    // Not logged in: 401
    // No user yet: 302 -> onboarding

     */
}

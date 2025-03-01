package at.sampas.personal_share.file.domain;

import at.sampas.personal_share.user.FileOwnerId;

public interface FileOwnerRepository {
    public FileOwner loadById(FileOwnerId id);
    public void save(FileOwner fileOwner);
}

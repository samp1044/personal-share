package at.sampas.personal_share.file.domain;

import at.sampas.personal_share.shared.AggregateRoot;
import at.sampas.personal_share.user.FileOwnerId;

import java.util.List;

public class FileOwner extends AggregateRoot<FileOwnerId> {
    private FileOwnerId id;
    private List<StoredFile> files;

    FileOwner(FileOwnerState state) {
        id = state.fileOwnerId();
    }

    FileOwnerState getState() {
        throw new UnsupportedOperationException();
    }

    public void addFile(StoredFile storedFile) {
        throw new UnsupportedOperationException();
    }

    @Override
    public FileOwnerId getId() {
        return this.id;
    }
}

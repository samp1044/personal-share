package at.sampas.personal_share.file.domain;

import java.io.InputStream;

public abstract class FileStorage {
    public abstract StoredFile StoreFile(InputStream content, FileName name, FileType type);

    protected StoredFile createStoredFile() {
        throw new UnsupportedOperationException();
    }
}
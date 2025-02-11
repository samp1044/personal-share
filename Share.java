import shared.AggregateRoot;
import shared.PreconditionException;

import java.util.HashSet;
import java.util.Set;

public class Share implements AggregateRoot<ShareId> {
    private ShareId id;
    private Owner owner;
    private Password password;
    private Set<ShareableFile> files;
    private boolean isLocked;

    public Share(Owner owner) {
        this.id = new ShareId();
        this.owner = owner;
        this.password = null;
        this.files = new HashSet<>();
        this.isLocked = true;
    }

    public void lockWithPassword(RawPassword password) {
        this.password = password.Hash();
    }

    public void unlock(RawPassword password) throws PreconditionException {
        if (this.password == null) {
            return;
        }

        if (!password.Hash().equals(this.password)) {
            throw new PreconditionException();
        }
    }

    public void includeFile(ShareableFile file) throws PreconditionException {
        if (!file.isOwnedBy(this.owner)) {
            throw new PreconditionException();
        }

        this.files.add(file);
    }

    @Override
    public ShareId getId() {
        return this.id;
    }
}

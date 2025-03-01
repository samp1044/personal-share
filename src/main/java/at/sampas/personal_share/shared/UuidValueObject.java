package at.sampas.personal_share.shared;

import java.util.Objects;
import java.util.UUID;

public abstract class UuidValueObject {
    private UUID id;

    protected UuidValueObject() {
        this.id = UUID.randomUUID();
    }

    protected UuidValueObject(UUID id) {
        this.id = id;
    }

    protected UuidValueObject(String id) {
        this.id = UUID.fromString(id);
    }

    public UUID getValue() {
        return this.id;
    }

    @Override
    public String toString() {
        return this.id.toString();
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj) return true;
        if (obj == null || obj.getClass() != this.getClass()) return false;
        UuidValueObject o = (UuidValueObject) obj;
        return Objects.equals(this.id, o.id);
    }

    @Override
    public int hashCode() {
        return Objects.hashCode(this.id);
    }
}

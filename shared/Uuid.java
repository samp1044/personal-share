package shared;

import java.util.Objects;
import java.util.UUID;

import static java.util.UUID.randomUUID;

public abstract class Uuid implements ValueObject {
    private final UUID uuid;

    public Uuid() {
        this.uuid = randomUUID();
    }

    public Uuid(UUID id) {
        this.uuid = id;
    }

    public UUID getValue() {
        return this.uuid;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Uuid uuid1 = (Uuid) o;
        return Objects.equals(uuid, uuid1.uuid);
    }

    @Override
    public int hashCode() {
        return Objects.hash(uuid);
    }
}
